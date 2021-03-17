# Crypto-Keepers

This repositiory contains code created during the NYDFS Techsprint for Digital Regulatory Reporting in Virtual Currency. More information here: https://www.dfs.ny.gov/techsprint  
![Full team](https://github.com/bmurdata/Crypto-Keepers/blob/master/cryptokeepers2/Images/teamCapture.PNG)
## Tech Team Contributors
* Brian Murphy- website development and backend intergration
* Kenneth O'Brein- Logic App creation and intergration
* Ben Royce- Logic App creation and DB Setup

## Uploaded Code
* Web app code, built using .Net Core MVC, with EntityFramework 6. Project file included for Visual Studio.  
* SQL Server database creation scripts, including a stored procedure.  
* Azure Logic Apps and API Connection files.  

## Website
  Allows create, view, update, and delete of alerts, including related tables from a website interface. 

## Logic Apps
  Two Logic apps were made, with different flows.
  * slack-bot: 
    * Check for new alerts in database
    * Parse new alerts
    * Post a message to a Slack channel about the alert
  * slack-test-app: 
    * Check for new files uploaded to Slack
    * Parse files
    * Upload to database
