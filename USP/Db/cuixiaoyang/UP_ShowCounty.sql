  
create proc [dbo].[UP_ShowCounty]  
@City char(6)      
as         
	if @City=''
	begin
		 --县级    
		 select [Code]    
		  ,[Parent]    
		  ,[Name]    
		  ,[WeatherCode]    
		  ,[LocationX]    
		  ,[LocationY]    
		  ,[Reserve]    
		  ,[Remark]    
		  from SysArea where [Parent] in(    
				  select [Code]    
				  from SysArea where [Parent] in     
				  (    
					 select [Code] from SysArea where Code=Parent    
				  ) and Code!=Parent
		  ) 
	end
	else 
	begin
	 --县级    
		 select [Code]    
		  ,[Parent]    
		  ,[Name]    
		  ,[WeatherCode]    
		  ,[LocationX]    
		  ,[LocationY]    
		  ,[Reserve]    
		  ,[Remark]    
		  from SysArea where [Parent] in(    
				  select [Code]    
				  from SysArea where [Parent] in     
				  (    
					 select [Code] from SysArea where Code=Parent    
				  ) and Code!=Parent
		  ) and Parent=@City
	end
	