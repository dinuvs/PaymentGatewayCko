
<body>
# PaymentGatewayCko
<br>
1. Bank Api Project acts like a acquiring bank 
<br>
   Currently only basic validations are added and there is no third party connections for money deductions etc 
   <br>
   <br>
2. PaymentGateway has the payment gateway component which talks to the bankAPi for validations
<br>
   This component persists the transactions to the SQL Server database table called TransactionDetail.
   <br>
   The Database connection and data access is achieved using Entity Framework Code first approach. 
   <br>
   Issue: There seems to be an issue in data posting to Bank API . The bank Api post works well as a stand alone. The issue needs a analysis and fix, due to lack of time haven't fixed it yet
   <br>
<br>

Improvements to be Done
<br>
1. Add logging, better error handling capture time taken for requests in logs
2. Add more unit tests 
3. Use AutoMapper for mapping or DTO 
4. Use API gateway using OCelot etc. 
5. Implement more validations in both payment and bank APi's , due to lack to time , could not add all the necesary validations. 

<BR>
<br>


HOW TO RUN THE APPLICATION

1. change appsettings file database connection string to the testable database server
2. Run Update-Database command from Package Manager console for PaymentGateway project to create the database table 
3. Run the BankAPI project first if possible 
4. Run the payment project next and test it using swagger UI. 


CLOUD TECHNOLOGIES TO BE CONSIDERED

1. Database can be AWS RDS MS SQL SERVER
2. The API's to be launched in the AWS Kubernetes Service (AKS) or in AWS EC2 machines with auto scaling switced on along with load balancer to handle scaling 
3. The Storing to Database component can be seperated out and queued using any streaming service to store to database if eventual consistency is ok . 
4. Route 53 service can be used for DNS 
5. AWS s3 can be used for logging along with Athena
6. AWS cloud Trail to be used for server and requests monitoring , etc. 
7. AWS Shield  can be used for DDOS protection 
   
</body>
