
create proc [dbo].[UP_ShowProvince]      
as       
 --省级  
 select [Code]  
      ,[Parent]  
      ,[Name]  
      ,[WeatherCode]  
      ,[LocationX]  
      ,[LocationY]  
      ,[Reserve]  
      ,[Remark]   
      from SysArea  where Code=Parent    
    