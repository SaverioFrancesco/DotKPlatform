# DotKPlatform


docker run --rm -it 
-p7033:7033 
-e ASPNETCORE_Kestrel__Certificates__Default__Password="MYPASS" 
-e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx 
-v %USERPROFILE%\.aspnet\https:/https/  
comissofrancesco/platformservice