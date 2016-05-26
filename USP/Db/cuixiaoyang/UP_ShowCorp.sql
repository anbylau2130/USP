
create PROCEDURE [dbo].[UP_ShowCorp]    
@PageIndex int = 1,    
@PageSize int = 10, 
@WhereStr nvarchar(200)='', 
@strOrder varchar(MAX) = '',    
@strOrderType varchar(max) = 'ASC'    
as    
select * from(    
    select convert(bigint, ROW_NUMBER() OVER(order by Name asc)) as RowNo,    
    convert(bigint, COUNT(0) OVER()) as RowCnt, *    
    FROM(    
         SELECT    
    a.[ID] ,b.Name as [Parent] ,a.[Priority] ,    
    a.[Name] ,a.LogoIcon,a.LogoUrl,a.[BriefName] ,a.[Certificate] ,    
    a.[CertificateNumber] ,a.[Ceo] ,a.[Postcode] ,    
    a.[Faxcode] ,a.[Linkman] ,a.[Mobile] ,    
    a.[Email] ,a.[Qq] ,a.[Wechat] ,    
    a.[Weibo] ,a.[VirtualIntegral] ,a.[RealIntegral] ,    
    c.[Name] as  FeeType,a.[PrepayValve] ,a.[Balance] ,    
    a.[FrozenBalance] ,a.[IncomingBalance] ,    
    a.[Commission] ,a.[Discount] ,j.Name as [Province] ,    
    k.Name as [Area] ,l.Name as [County] ,a.[Community] ,    
    a.[Address] ,d.Name as [Status] ,e.Name as [Type] ,    
    a.[Grade] ,a.[Vocation] ,a.[Reserve] ,    
    a.[Remark] ,g.RealName as [Creator] ,a.[CreateTime] ,    
    h.RealName as [Auditor] ,a.[AuditTime] ,i.RealName [Canceler] ,    
    a.[CancelTime]    
    FROM SysCorp  a    
         left join SysCorp b on a.Parent=b.ID    
         left join SysCorpFeeType c on a.FeeType=c.ID    
         left join SysCorpStatus d on a.Status=d.ID    
         left join SysCorpType e on a.Type=e.ID    
         left join SysCorpVocation f on a.Vocation =f.ID    
         left join SysOperator g on a.Creator=g.ID    
         left join SysOperator h on a.Auditor=h.ID    
         left join SysOperator i on a.Canceler=i.ID    
         left join SysArea j on a.Province=j.Code    
         left join SysArea k on a.Area = k.Code    
         left join SysArea l on a.County =l.Code    
         where a.ID !=0  
    ) AS a  where a.Name like '%'+@WhereStr+'%'
)    
AS temp 
WHERE RowNo BETWEEN (@PageIndex-1)*@PageSize+1 AND @PageIndex*@PageSize
  