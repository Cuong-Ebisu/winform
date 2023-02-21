CREATE TABLE EMPLOYEE(
	Employee_ID int primary key identity(1, 1),
	Employee_Name varchar(100),
	Employee_FName varchar(100),
	Employee_Degign varchar(100),
	Employee_Email varchar(100),
	Emp_ID varchar(100),
	Gender varchar(100),
	Addrss varchar(100)
);

INSERT INTO EMPLOYEE 
VALUES ('Van A','Nguyen','Progammer','A@gmail.com','4523','Male','Khanh Hoa');

INSERT INTO EMPLOYEE 
VALUES ('Van B','Nguyen','Progammer','B@gmail.com','82674','Female','Da Nang');

INSERT INTO EMPLOYEE 
VALUES ('Van C','Nguyen','Progammer','C@gmail.com','2354235','Male','Ho Chi Minh');

INSERT INTO EMPLOYEE 
VALUES ('Van D','Nguyen','Progammer','D@gmail.com','23454','Female','Vung Tau');

INSERT INTO EMPLOYEE 
VALUES ('Van F','Nguyen','Progammer','E@gmail.com','45231323','Male','Ha Noi');

INSERT INTO EMPLOYEE 
VALUES ('Van E','Nguyen','Progammer','F@gmail.com','4563456','Female','Khanh Hoa');

SELECT *FROM EMPLOYEE;
