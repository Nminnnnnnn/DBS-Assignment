USE [EducationSystemDB]
GO
CREATE PROCEDURE UpdateStudentAndUser
    @UserId INT,
    @Email VARCHAR(50),
    @Password VARCHAR(50),
    @FullName NVARCHAR(50),
    @IdentityNumber VARCHAR(50) = NULL,
    @BirthDate DATE = NULL,
    @Gender NVARCHAR(50),
    @Department NVARCHAR(50),
    @Status NVARCHAR(50),
    @AdmissionDate DATE,
    @LearningStatus NVARCHAR(50),
    @ErrorMessage NVARCHAR(MAX) OUTPUT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Kiểm tra độ dài Email
        IF @Email IS NULL OR LEN(@Email) = 0 OR LEN(@Email) > 50
        BEGIN
            SET @ErrorMessage = N'Lỗi: Email không hợp lệ. Độ dài phải từ 1 đến 50 ký tự.';
            RETURN;
        END

		-- Kiểm tra tính hợp lệ của Email
        IF NOT (@Email LIKE '%@%.%')
        BEGIN
            SET @ErrorMessage = N'Lỗi: Email không hợp lệ. Phải có định dạng hợp lệ (vd: example@domain.com).';
            RETURN;
        END

		-- Kiểm tra độ dài Password
        IF @Password IS NULL OR LEN(@Password) = 0 OR LEN(@Password) > 50
        BEGIN
            SET @ErrorMessage = N'Lỗi: Password không hợp lệ. Độ dài phải từ 1 đến 50 ký tự.';
            RETURN;
        END

		-- Kiểm tra độ dài Fullname
        IF @FullName IS NULL OR LEN(@FullName) = 0 OR LEN(@FullName) > 50
        BEGIN
            SET @ErrorMessage = N'Lỗi: Fullname không hợp lệ. Độ dài phải từ 1 đến 50 ký tự.';
            RETURN;
        END

		-- Kiểm tra độ dài Gender
        IF @Gender IS NULL OR LEN(@Gender) = 0 OR LEN(@Gender) > 50
        BEGIN
            SET @ErrorMessage = N'Lỗi: Gender không hợp lệ. Độ dài phải từ 1 đến 50 ký tự.';
            RETURN;
        END

		-- Kiểm tra độ dài Department
        IF @Department IS NULL OR LEN(@Department) = 0 OR LEN(@Department) > 50
        BEGIN
            SET @ErrorMessage = N'Lỗi: Department không hợp lệ. Độ dài phải từ 1 đến 50 ký tự.';
            RETURN;
        END

		-- Kiểm tra độ dài Identity Number
        IF @IdentityNumber IS NOT NULL AND LEN(@IdentityNumber) > 50
        BEGIN
            SET @ErrorMessage = N'Lỗi: Identity Number không hợp lệ. Độ dài không được quá 50 ký tự.';
            RETURN;
        END

		-- Check không empty Admission Date
        IF @AdmissionDate IS NULL
        BEGIN
            SET @ErrorMessage = N'Lỗi: Admission Date không được để trống.';
            RETURN;
        END

		-- Kiểm tra độ dài LearningStatus
        IF @LearningStatus IS NULL OR LEN(@LearningStatus) = 0 OR LEN(@LearningStatus) > 50
        BEGIN
            SET @ErrorMessage = N'Lỗi: Learning Status không hợp lệ. Độ dài phải từ 1 đến 50 ký tự.';
            RETURN;
        END
	-- Kiểm tra độ dài LearningStatus
        IF LEN(@Status) = 0 OR LEN(@Status) > 50
        BEGIN
            SET @ErrorMessage = N'Lỗi: Status không hợp lệ. Độ dài phải từ 1 đến 50 ký tự.';
            RETURN;
        END

        -- Kiểm tra Email có tồn tại trong bảng User chưa
        IF EXISTS (SELECT 1 FROM [User] WHERE Id != @UserId AND Email = @Email)
        BEGIN
            SET @ErrorMessage = N'Lỗi: Email đã tồn tại trong bảng User.';
            RETURN;
        END

        -- Cập nhật User
        UPDATE [dbo].[User]
        SET 
            Email = @Email,
            Password = @Password,
            FullName = @FullName,
            IdentityNumber = @IdentityNumber,
            BirthDate = @BirthDate,
            Gender = @Gender,
            Department = @Department,
            Status = @Status
        WHERE Id = @UserId;

        IF @@ROWCOUNT = 0
        BEGIN
            SET @ErrorMessage = N'Lỗi: Không tìm thấy User với Id đã cho.';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Cập nhật Student
        UPDATE [dbo].[Student]
        SET 
            AdmissionDate = @AdmissionDate,
            LearningStatus = @LearningStatus
        WHERE UserId = @UserId;

        IF @@ROWCOUNT = 0
        BEGIN
            SET @ErrorMessage = N'Lỗi: Không tìm thấy Student với UserId đã cho.';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Hoàn tất giao dịch
        COMMIT TRANSACTION;

        SET @ErrorMessage = N'Cập nhật thành công.';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @ErrorMessage = ERROR_MESSAGE();
    END CATCH
END