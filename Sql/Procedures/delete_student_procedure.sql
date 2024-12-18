USE [EducationSystemDB]
GO
CREATE PROCEDURE DeleteStudentAndUser
    @UserId INT,
    @ErrorMessage NVARCHAR(MAX) OUTPUT
AS
BEGIN
		BEGIN TRANSACTION;
        -- Kiểm tra UserId có tồn tại trong bảng User hay không
        IF NOT EXISTS (SELECT 1 FROM [dbo].[User] WHERE Id = @UserId)
        BEGIN
            SET @ErrorMessage = N'Lỗi: Không tìm thấy User với Id đã cho.';
            ROLLBACK TRANSACTION;
            RETURN;
        END
		-- Kiểm tra trạng thái User
		IF EXISTS (SELECT 1 FROM [dbo].[User] WHERE Id = @UserId AND Status = 'Active')
		BEGIN
			SET @ErrorMessage = N'Lỗi: Không thể xóa User đang ở trạng thái hoạt động.';
			ROLLBACK TRANSACTION;
			RETURN;
		END
		BEGIN TRY
			-- Xóa Student
			DELETE FROM [dbo].[Student]
			WHERE UserId = @UserId;
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
			SET @ErrorMessage = ERROR_MESSAGE();
			RETURN;
		END CATCH
	BEGIN TRY
        -- Xóa User
        DELETE FROM [dbo].[User]
        WHERE Id = @UserId;

        -- Kiểm tra xem việc xóa có thành công hay không
        IF @@ROWCOUNT = 0
        BEGIN
            SET @ErrorMessage = N'Lỗi: Không thể xóa User hoặc UserId không hợp lệ.';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Hoàn tất giao dịch
        COMMIT TRANSACTION;

        SET @ErrorMessage = N'Xóa thành công.';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @ErrorMessage = ERROR_MESSAGE();
    END CATCH
END