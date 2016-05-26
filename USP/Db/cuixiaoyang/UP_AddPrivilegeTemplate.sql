
                
create proc [dbo].[UP_AddPrivilegeTemplate]               
   @CorpType bigint,             
   @Privileges nvarchar(500),        
   @Creator bigint,               
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
                
   --判断类型表是否存在相应的数据 ,如果存在就删除               
   select @count=COUNT(*) from SysPrivilegeTemplate where CorpType=@CorpType                
   if @count>0                
   begin                
   delete from SysPrivilegeTemplate where CorpType=@CorpType        
   end                
                    
  begin try                
  begin tran TRAN1                
     while(charindex(',',@Privileges)<>0)        
  begin        
    --第一个','之前的字符串        
    set @id=substring(@Privileges,1,charindex(',',@Privileges)-1)        
    --将第一个','后面的字符串重新赋给@ids        
    set @Privileges=stuff(@Privileges,1,charindex(',',@Privileges),'')        
    --最后一个字符串      
     insert into SysPrivilegeTemplate        
     (CorpType,Privilege,Creator,CreateTime)        
     values        
     (@CorpType,@id,@Creator,@datetime)       
    
  end    
   if(charindex(',',@Privileges)=0)        
  begin        
       insert into SysPrivilegeTemplate        
      (CorpType,Privilege,Creator,CreateTime)        
      values        
      (@CorpType,@Privileges,@Creator,@datetime)     
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