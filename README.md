# MVC_CRUD

* Company

| Id | Name | Creation Date  |
|---|------|----------------|
| Primary Key | String | DateTime |

* Office

| Id | Country | City | Street | Street number | isHQ | Company |
| --- | ------- | ---- | ------ | ------------- | ---- | --- |
| Primary Key | String | String | String | Short | Boolean | Foreign Key |



* Office_Employee
| Id | Office | Employee |
| --- | --- | --- |
| Primary Key | Foreign Key | Foreign Key |

* Documents
| Id | Document | Office |
| --- | --- | --- |
| Primary Key | byte[]/String | Foreign Key |