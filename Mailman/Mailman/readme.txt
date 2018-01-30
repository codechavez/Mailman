******************************************
***            MAILMAN                 ***  
***									   ***
******************************************


To configure SMTP Add the following in your app.config/web.config file under 'appSettings'

<add key="SMTPClient:Host" value="YOUR SMTP SERVER" />
<add key="SMTPClient:Useremail" value="YOUR SENDER EMAIL" />
<add key="SMTPClient:Userpwd" value="YOUR SENDER PASSWORD" />
<add key="SMTPClient:Port" value="SMTP SERVER PORT" />


To configure SMTP Add the following in your appsettings.json file

"SMTPClient":{
	"Host": "YOUR SMTP SERVER",
	"Useremail": "YOUR SENDER EMAIL",
	"Userpwd":"YOUR SENDER PASSWORD",
	"Port": SMTP SERVER PORT
}