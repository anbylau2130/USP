     
create proc [dbo].[UP_AuditorPrivilegeTemplate]               
   @CorpType bigint,             
   @Privileges nvarchar(500),        
   @Auditor bigint,               
   @IsSuccess  VARCHAR(50)='1' out,     --标示位 1成功 0失败                
   @ProcMsg varchar(500)='success' out   --返回信息                
as                
BEGIN                
  Set XACT_ABORT ON                
  set nocount off                
  declare @count int          
  declare @id nvarchar(200)               
  declare @datetime nvarchar(50)= CONVERT(varchar(100), GETDATE(), 121)              
              
  set @IsSuccess='1'                
  set @ProcMsg='success'                
          
  begin try                
  begin tran TRAN1                
		  while(charindex(',',@Privileges)<>0)        
		  begin        
				  --第一个','之前的字符串        
				  set @id=substring(@Privileges,1,charindex(',',@Privileges)-1)        
				  --将第一个','后面的字符串重新赋给@ids        
				  set @Privileges=stuff(@Privileges,1,charindex(',',@Privileges),'')        
				  --最后一个字符串      
				  update SysPrivilegeTemplate  
				  set Auditor=@Auditor,AuditTime=@datetime  
				  where CorpType=@CorpType and Privilege=@id  
		  end    
		  if(charindex(',',@Privileges)=0)        
		  begin        
				update SysPrivilegeTemplate  
				set Auditor=@Auditor,AuditTime=@datetime  
				where CorpType=@CorpType and Privilege=@Privileges  
		  end            
  COMMIT TRANSACTION TRAN1                
  end try                
  begin catch                
		   print  ERROR_MESSAGE()                
		   set @IsSuccess=0                
		   SET @ProcMsg= ERROR_MESSAGE()  
		   rollback tran
  end catch                
end 