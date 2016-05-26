
         
create proc [dbo].[UP_CancelCorp]               
   @Corp bigint,   
   @Canceler bigint,         
   @IsSuccess  VARCHAR(50)='1' out,     --标示位 1成功 0失败                
   @ProcMsg varchar(500)='success' out   --返回信息                
as                
BEGIN                
  Set XACT_ABORT ON                
  set nocount off                
  begin try  
    set @IsSuccess='1'          
    set @ProcMsg='success'                        
	declare @datetime nvarchar(50)= CONVERT(varchar(100), GETDATE(), 121)
	update SysCorp set Canceler=@Canceler,CancelTime=@datetime where ID=@Corp           
  end try                
  begin catch                
   print  ERROR_MESSAGE()                
   set @IsSuccess=0                
   SET @ProcMsg= ERROR_MESSAGE()                
   rollback tran                 
  end catch                
end 


