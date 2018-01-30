# Mailman
Mailman is a super simple and basic library that everyday developer use when working with SMTP. You can send emails with attachment, BCC and/or CC with default credentals or not.

**One for All** approach, compatiable with

* [x] .NET CORE 2.0
* [x] .NET Framework 4.6.1
* [x] .NET Framework 4.6.2
* [x] .NET Framework 4.7
* [x] .NET Framework 4.7.1


To configure SMTP Add the following in your app.config/web.config file under 'appSettings'

``` xml
<add key="SMTPClient:Host" value="YOUR SMTP SERVER" />
<add key="SMTPClient:Useremail" value="YOUR SENDER EMAIL" />
<add key="SMTPClient:Userpwd" value="YOUR SENDER PASSWORD" />
<add key="SMTPClient:Port" value="SMTP SERVER PORT" />
```

To configure SMTP Add the following in your appsettings.json file
``` json
"SMTPClient":{
	"Host": "YOUR SMTP SERVER",
	"Useremail": "YOUR SENDER EMAIL",
	"Userpwd":"YOUR SENDER PASSWORD",
	"Port": SMTP SERVER PORT
}
```