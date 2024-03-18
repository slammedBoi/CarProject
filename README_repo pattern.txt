Repository Pattern
 - Should not have Application and Context directly talk
	- If context were to change (row, column etc) break application
	- If new context introduced, would need brand new code to handle context
	- Introduce Repository to handle in between Application and Context

 - One interface repository, many repositories that derive from interface
	- create interface object as specific repository type
	- interfaces CANNOT be instantiated 
	- @ runtime(?) computer understands which repository that must be used to retrieve correct data
	
 - Must create a context for specific repository 
	- context is data access for repository 
