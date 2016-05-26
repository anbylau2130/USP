
create proc [dbo].[UP_ShowCity]  
@Province char(6)       
as         
      if @Province=''
      begin
		  --市级    
		  select [Code]    
		  ,[Parent]    
		  ,[Name]    
		  ,[WeatherCode]    
		  ,[LocationX]    
		  ,[LocationY]    
		  ,[Reserve]    
		  ,[Remark]    
		  from SysArea where [Parent] in     
		  (    
				select [Code] from SysArea where Code=Parent    
		  ) and Code!=Parent 
      end
      else 
      begin
			--市级    
		  select [Code]    
		  ,[Parent]    
		  ,[Name]    
		  ,[WeatherCode]    
		  ,[LocationX]    
		  ,[LocationY]    
		  ,[Reserve]    
		  ,[Remark]    
		  from SysArea where [Parent] in     
		  (    
				select [Code] from SysArea where Code=Parent    
		  ) and Code!=Parent and Parent=@Province
      
      end
         
     