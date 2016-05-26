
          
create proc [dbo].[UP_AddCorp]          
   @CorpName varchar(100),          
   @CorpType bigint, 
   @ParentCorp bigint, 
   @LoginName nvarchar(50),
   @Password  VARCHAR(50),  
   @IsSuccess  VARCHAR(50)='1' out,     --标示位 1成功 0失败          
   @ProcMsg varchar(500) out   --返回信息          
as          
BEGIN          
          
  Set XACT_ABORT ON          
  set nocount off          
  declare @count int          
  declare @SysCorpID bigint          
  declare @datetime nvarchar(50)          
  select @datetime = CONVERT(varchar(100), GETDATE(), 121)          
  set @IsSuccess='1'          
  set @ProcMsg='success'          
          
   --判断类型表是否存在相应的数据          
   select @count=COUNT(*) from SysCorp where Name=@CorpName          
   if @count>0          
   begin          
  set @IsSuccess=0          
  set @ProcMsg='已存在相同的公司名称'          
  return          
   end          
  --增加一条操作员数据          
  select @count=COUNT(*) from SysOperator where SysOperator.LoginName=@LoginName          
  if @count>0          
  begin          
    set @IsSuccess=0          
    set @ProcMsg='已存在相同的管理员账号'          
       return          
  end          
              
  begin try          
  begin tran TRAN1          
      --如果不存在parent=0系统菜单--则生成系统数据          
          insert into SysCorp          
          (          
            Parent, Priority, Name,          
            BriefName, Certificate, CertificateNumber,          
            Ceo, Postcode, Faxcode,          
            Linkman, Mobile, Email,          
            Qq, Wechat, Weibo,          
            VirtualIntegral, RealIntegral, FeeType,          
            PrepayValve, Balance, FrozenBalance,          
            IncomingBalance, Commission, Discount,          
            Province, Area, County,          
            Community, Address, Status,          
            Type, Grade, Vocation,          
            Reserve, Remark, Creator,          
            CreateTime, Auditor, AuditTime,          
            Canceler, CancelTime          
          )          
          values          
          (          
            @ParentCorp, 0, @CorpName,          
            @CorpName, '', '',          
            '', '', '',          
            '', '', '',          
            '', '', '',          
            0, 0, 0,          
            0, 0, 0,          
            0, 0, 1,          
            '110000', '110000', '110000',          
            '110000', '', 0,          
            0, 0, 0,          
            '', '', 0,          
            @datetime, null, null,          
            null, null          
           );          
          select @SysCorpID=@@IDENTITY          
                 
          declare @SysOperatorID bigint          
                    
          insert into SysOperator          
            (          
              Corp, LoginName, RealName,          
              Password, Mobile, IdCard,          
              Email, WechatOpenid, AlipayOpenid,          
              Weibo,AvailableIP, WeatherCode,          
              VirtualIntegral,RealIntegral, Balance,          
              FrozenBalance, IncomingBalance, Commission,          
              Discount, Province, Area,          
              County, Community,Address,          
              Status, Skin, Grade,          
              Star,Session, LoginTime,          
              LoginIP, LoginAgent,LoginCount,          
              LoginErrorCount, FrozenStartTime,FrozenEndTime,          
              Reserve, Remark, Creator,          
              CreateTime,Auditor, AuditTime,          
              Canceler, CancelTime          
            )          
            values (          
                @SysCorpID, @LoginName, @CorpName+'系统管理员',          
                @Password,@datetime, @datetime,          
                '', '', '',          
                '', '', '110000',          
0, 0, 0,          
                0, 0, 0,          
                1, '110000', '110000',          
                '110000', '110000', '',          
                0, 0, 0,          
                0, '', null,          
                null, null, 0,          
                0, null, null,          
                '', '', 0,          
                @datetime, null, null,          
                null, null          
              );          
          select @SysOperatorID=@@IDENTITY          
          
            --增加一条角色信息                    
            declare @SysRoleID bigint          
          
          insert into SysRole (          
              Corp, Name, Type,          
              Reserve, Remark, Creator,          
              CreateTime, Auditor, AuditTime,          
              Canceler, CancelTime          
           )          
          values (          
              @SysCorpID, @CorpName+'administrators', 1,          
              null, null, 0,          
              @datetime, 0, @datetime,          
              null, null          
           );          
          
          select @SysRoleID=@@IDENTITY          
          
                 
          --临时表插入到正式表          
          insert into SysRoleMenu          
          (          
            Role,Menu,Reserve,          
            Remark,Creator,CreateTime,          
            Auditor,AuditTime,Canceler,          
            CancelTime          
          )  select          
          @SysRoleID,ID,null,null,0  ,@datetime,0,@datetime,null,null from SysMenu          
                    
  COMMIT TRANSACTION TRAN1          
  end try          
  begin catch          
   print  ERROR_MESSAGE()          
   set @IsSuccess=0          
   SET @ProcMsg= ERROR_MESSAGE()          
   rollback tran           
  end catch          
end          