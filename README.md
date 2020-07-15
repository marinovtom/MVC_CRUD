# MVC_CRUD

* Company

| Id | Name | Creation Date  |
|---|------|----------------|
| Primary Key | String | DateTime |

* Office

| Id | Country | City | Street | Street number | isHQ | Company |
| --- | ------- | ---- | ------ | ------------- | ---- | --- |
| Primary Key | String | String | String | Short | Boolean | Foreign Key |

* Employee

| Id | First name | Last name | Starting date | Salary | Vacation days | Experience level | Image |
| ---- | ------ | ------ | ------- | ----------- | ------ | ------ | ------ |
| Primary Key | String | String | DateTime | Int | Short | Enum | byte[]/String |

* Office_Employee
| Id | Office | Employee |
| --- | --- | --- |
| Primary Key | Foreign Key | Foreign Key |

* Documents
| Id | Document | Office |
| --- | --- | --- |
| Primary Key | byte[]/String | Foreign Key |