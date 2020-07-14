# MVC_CRUD

* Company

| Id | Name | Creation Date  |
|---|------|----------------|
| Primary Key | String | DateTime |

* Office

| Id | Country | City | Street | Street number | Documents | isHQ | Company |
| --- | ------- | ---- | ------ | ------------- | --------- | ---- | --- |
| Primary Key | String | String | String | Short | byte[]/String | Boolean | Foreign Key |

* Employee

| Id | First name | Last name | Starting date | Salary | Vacation days | Experience level | Image | Company |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Primary Key | String | String | DateTime | Int | Short | Enum | byte[]/String | Foreign Key |