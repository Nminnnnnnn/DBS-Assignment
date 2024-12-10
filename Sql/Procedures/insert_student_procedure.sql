USE [EducationSystemDB]
GO
CREATE PROCEDURE InsertStudentAndUser
    @Email NVARCHAR(50),
    @Password NVARCHAR(50),
    @FullName NVARCHAR(50),
    @IdentityNumber NVARCHAR(50) = NULL,
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
        DECLARE @UserId INT;

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

	-- Kiểm tra độ dài Identity Number
        IF @IdentityNumber IS NOT NULL AND LEN(@IdentityNumber) > 50
        BEGIN
            SET @ErrorMessage = N'Lỗi: Identity Number không hợp lệ. Độ dài không được quá 50 ký tự.';
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
	-- Kiểm tra độ dài Status
        IF LEN(@Status) = 0 OR LEN(@Status) > 50
        BEGIN
            SET @ErrorMessage = N'Lỗi: Status không hợp lệ. Độ dài phải từ 1 đến 50 ký tự.';
            RETURN;
        END

        -- Kiểm tra Email có tồn tại trong bảng User chưa
        IF EXISTS (SELECT 1 FROM [User] WHERE Email = @Email)
        BEGIN
            SET @ErrorMessage = N'Lỗi: Email đã tồn tại trong bảng User.';
            RETURN;
        END

        -- Thêm mới vào bảng User
        INSERT INTO [User] (Email, Password, FullName, IdentityNumber, BirthDate, Gender, Department, Status)
        VALUES (@Email, @Password, @FullName, @IdentityNumber, @BirthDate, @Gender, @Department, @Status);

        -- Lấy UserId vừa được thêm
        SET @UserId = SCOPE_IDENTITY();

        -- Thêm mới vào bảng Student
        INSERT INTO [Student] (UserId, AdmissionDate, LearningStatus)
        VALUES (@UserId, @AdmissionDate, @LearningStatus);

        -- Trả về thông báo thành công
        SET @ErrorMessage = N'Thêm User và Student thành công!';
    END TRY
    BEGIN CATCH
        -- Xử lý lỗi hệ thống
        SET @ErrorMessage = ERROR_MESSAGE();
    END CATCH
END;