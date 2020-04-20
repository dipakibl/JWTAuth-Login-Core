# JWTAuth-Login-Core


how creating a Jwt authentication based login project.
- first Create a new .net core api application project
- create a new user class.
- create a context class.
- set connectionstring in appsetting.json.
- set a dbcontext in startup.
-than after ,add migrations.
- Configure JWT based certification in the project. To do this, we need to register the JWT Authentication Schema using the "AddAuthentication" method and specifying the 
  JwtBearerDephaults.AuthenticationScheme. Here, we configure the authentication schema with the JWT Bearer options.
- set Jwt key and Issuer in appsettings.json file.
- set UseAuthentication method before UseMvc method in Configure method in startup file.-
- Create a new api controller.
- Create an "API / Login Count" method to generate the token. Made unauthorized first response. Then make the user an AuthenticateUser. Generate token from Authenticate user.
- create a generate token method when user authenticates. And call it.
- Now, create a Get User List method to get a list of values by passing this token into the authentication HTTP header. Set the token to Postman to check it.