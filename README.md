
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


Improvements to be Done
<br>
1. Add logging, better error handling capture time taken for requests in logs
2. Add more unit tests 
3. Use AutoMapper for mapping or DTO 
4. Use API gateway using OCelot etc. 
5. Implement more validations in both payment and bank APi's , due to lack to time , could not add all the necesary validations. 



   
</body>
