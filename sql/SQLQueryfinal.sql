--use master
--drop database daka
--go

create database daka
go

use daka
go
---------------------------------- הגדרת טבלאות -------------------------------------
 
create table [employee in dep]
(
department_code int,
employee_pass_id nvarchar(30)

)
go 
--טבלת ימים
CREATE TABLE [WEEK DAYS]
(	[day_off_id] int NOT NULL PRIMARY KEY,
	[day_desc] nvarchar NULL
)
GO

--טבלת תעסוקה
CREATE TABLE [OCCUPATION]
(
[occupation_code] int  NOT NULL primary key,
[occupation_desc] nvarchar(30)  NOT NULL
)
GO

---טבלת של היסטוריית תעסוקה
--CREATE TABLE [EMPLOYMENT COMPANY DATES]
--(	[work_p_id] int NOT NULL identity(1,1) PRIMARY KEY,
--	[employee_pass_id] int NOT NULL,
--	[Registration_start] [date] NOT NULL,
--	[Registration_end] [date] NULL
--)
--GO

--טבלת מצב משפחתי
CREATE TABLE [family status]
(	[fam_stat_code] int NOT NULL PRIMARY KEY,
	[fam_stat_desc] nvarchar(30) NOT NULL
)
GO


--טבלת עובדים
CREATE TABLE [EMPLOYEE]
(
	[employee_pass_id] nvarchar(30) NOT NULL PRIMARY KEY,
	[lname] nvarchar (30) NOT NULL,
	[fname] nvarchar (30) NOT NULL ,
	[birthday] [date] NOT NULL ,
	[gender] [bit] NOT NULL ,
	[Picture] [image] NULL ,
	[origin_country] int NOT NULL,
	[il_citizen] bit not null,
	[add_city] int NOT NULL,
	[add] nvarchar (100)  NULL,
	[add_num] smallint  NULL,
	--[city_Code] int NULL ,
	[phone] int NOT NULL ,
	[com_app] bit NOT NUll, --מגורי חברה או לא
	--[visa_id] varchar(100) NOT NULL ,
	--[visa_valid] [date] NOT NULL,	--תוקף דרכון
	--[visa_pic] [image] NOT NULL ,
	--[work_p_id] int NOT NULL FOREIGN KEY REFERENCES [EMPLOYMENT COMPANY DATES]([work_p_id]),
	[michpal_id] int NULL,
	[insurance] bit NOT NULL,
	[com_insurance] bit NOT NULL,
	[fam_stat_code] int NOT NULL,
	--[contract_id] varchar(100) NOT NULL ,--מספר ביטוחFOREIGN KEY REFERENCES Persons(PersonID)
	[salary_hour]  int NOT NULL,--שכר שעתי
	[salary_overtime]  int NOT NULL,--שכר שעות נוספות
	[salary_trans] int NOT NULL,--שכר נסיעות
	[day_off_id] int NOT NULL CHECK ( [day_off_id]<=1 and [day_off_id]>=7),--יום מנוחה FOREIGN KEY REFERENCES [WEEK DAYS] (day_off_id)
	[sabatical] int NOT NULL ,--יום שבתון
	[occupation_code] int  NULL ,
	[active] bit not null,
	--[disable_reason] nvarchar (120) null
	food_incloud bit,
	food_pay int,
	monthly_rent int,
	final_bill bit
)
GO


create table DOCS
(
doc_id nvarchar(120) not null primary key,
emp_id nvarchar(30) not null,
doctype_id int not null,
img_url nvarchar (120) null,
last_update date not null,
ex_date date null,
active bit not null
)
go

Create table [salary_trans]
(
 [salary_trans] int primary key,
 trans_desc nvarchar(30),
)
go

--create table EMP_DOCS
--(
--doc_id nvarchar (120) not null,
--emp_id nvarchar(30) not null,
--)
--go


create table DOC_TYPE
(
doctype_id int identity(1,1) not null primary key,
doc_name nvarchar (100),
doc_desc nvarchar(120)
)
go

CREATE TABLE DEPARTMENT_TYPE
(department_code int identity(1,1) primary key,
department_name nvarchar (100)
)

--טבלת ויזה
--CREATE TABLE VISAS
--( 
--[visa_id] nvarchar(100) NOT NULL PRIMARY KEY,
--[visa_valid] [date] NOT NULL,	--תוקף דרכון
--[visa_pic] [image] NOT NULL ,

--)
--GO


--טבלת מדינות

CREATE TABLE [dbo].[Country](
	[ID] [int] IDENTITY(1,1) NOT NULL primary key,
	[CountryName] [nvarchar](100) NOT NULL
)
GO

CREATE TABLE CITY
(
	[ID] [int] IDENTITY(1,1) NOT NULL primary key,
	[CityName] [nvarchar](100) NOT NULL

)
GO

--טבלת בית עסק
CREATE TABLE BUSINESSES
(
	[bus_id] int Primary KEy not null,
	[bus_name] nvarchar(120) not null,
	[add_city] int NOT  NULL,
	[add] nvarchar (100)  NULL,
	[add_num] smallint  NULL,
	--[city_Code] int NULL ,
	[phone] int NULL ,
	[bus_type_code] int not null, --foreign key references business type
	[contract_code] int not null, -- foreign key references contracts

 department_code int,
 commence_date  date

)
GO

create table [BUSINESS TYPE]
(
[bus_type_code] int primary key NOT NULL,
[bus_type_name] nvarchar(30) not null,
[bus_type_desc] nvarchar(100)  null,
)
GO

create table [CONTRACTS]
(
[contract_code] int identity(1,1) NOT NULL primary key,
contype_id int not null,
[signature_sdate] date NOT NULL,
[signature_fdate] date NULL,
[contract_pic] image NOT NULL
)
GO

create table CONTRACT_TYPE
(
contype_id int identity(1,1) not null primary key,
cont_name nvarchar (100),
cont_desc nvarchar(120)
)
go

create table BUS_CONTR
(
[bus_id] int not null,
[contract_code] int  NOT NULL
)
go



CREATE TABLE [contacts to business]
(
[contact_id] int not null primary key,
[contact_name] nvarchar(30) not null,
[phone] int not null,
[email] nvarchar(30) not null,
[role_id] int not null--forign

)
GO

CREATE TABLE[ROLES OF CONTACTS]
(
[role_id] int not null primary key identity(1,1),
[role_name] nvarchar(30) not null,
[role_desc] nvarchar(100) null,
)
GO

CREATE TABLE [contacts in business]
(
[bus_id] int not null,--forign
[contact_id] int not null,--forign
)
GO

CREATE TABLE [employee in business]
(
[employee_pass_id] nvarchar(30) not null,
[bus_id] int not null,
[start_date] date not null,
[end_date] date null
)
go

CREATE TABLE [USERS]
(
[uid] int primary key not null identity(1,1),
[u_name]  nvarchar(100) not null,
[u_pwd] nvarchar(100) not null,
[U_type_code] int not null,--forign
[phone] int not null
)
GO

CREATE TABLE [USERS TYPES]
(
[U_type_code] int not null primary key identity(1,1),
[U_type_name] nvarchar(100) not null
)
GO

CREATE TABLE [LOG]
(
update_id int identity(1,1) primary key not null,
[uid] int not null,
emp_id nvarchar(30)  null,
bus_id int null,
[update_desc] nvarchar(120)
)
GO

create table [DISABLE_REASON]
(
did int identity (1,1) primary key not null,
d_name nvarchar (60) not null 
)
go

create table [EMP_DIS_REASON]
(
did int not null,
emp_id nvarchar(30) not null,
[description] nvarchar (240)
)

-------------------------------KEYS----------------------------------
--ALTER TABLE [EMPLOYMENT COMPANY DATES]
--ADD FOREIGN KEY ([employee_pass_id]) REFERENCES EMPLOYEE([employee_pass_id]);


alter table EMPLOYEE
add constraint fk_country foreign key ([origin_country]) references [dbo].[Country] ([ID])
go

alter table [dbo].[EMP_DIS_REASON]
add
constraint pk_em_dis_r primary key ([did],[emp_id])
go



alter table [contacts in business]
add
constraint pk_contacts primary key ([bus_id],[contact_id])
go

alter table [contacts in business]
add
constraint fk_business foreign key ([bus_id]) references [dbo].[BUSINESSES]([bus_id])
go

alter table [contacts in business]
add
constraint fk_contact foreign key ([contact_id]) references [dbo].[contacts to business]([contact_id])
go

alter table [BUS_CONTR]
add 
constraint pk_cont primary key ([contract_code],[bus_id])
go

alter table [employee in business]
add constraint pk_contact primary key ([bus_id],[employee_pass_id])
go




--alter table EMP_DOCS
--add constraint pk_doc_employee primary key (doc_id ,emp_id)
--go

alter table [employee in business]
add
constraint fk_bus foreign key ([bus_id]) references [dbo].[BUSINESSES]([bus_id])
go



alter table [employee in business]
add
constraint fk_emp foreign key ([employee_pass_id]) references [dbo].[EMPLOYEE]([employee_pass_id])
go

alter table [dbo].[BUSINESSES]
add
constraint fk_b_type foreign key ([bus_type_code]) references [dbo].[BUSINESS TYPE]([bus_type_code])
go

alter table [dbo].[EMPLOYEE]
add
constraint fk_ST foreign key ([salary_trans]) references [dbo].[salary_trans] ([salary_trans])
go

alter table [contacts to business]
add
constraint fk_c_role foreign key ([role_id]) references [dbo].[ROLES OF CONTACTS] ([role_id])
go

alter table [dbo].[EMPLOYEE]
add
constraint fk_f_status foreign key ([fam_stat_code]) references [dbo].[family status] ([fam_stat_code])
go

alter table [dbo].[EMPLOYEE]
add
constraint fk_e_occu foreign key ([occupation_code]) references [dbo].[OCCUPATION] ([occupation_code])
go


alter table [dbo].[EMPLOYEE]
add
constraint fk_DOW foreign key ([day_off_id]) references [dbo].[WEEK DAYS]([day_off_id])
go


alter table [dbo].[USERS]
add
constraint fk_u_type foreign key ([U_type_code]) references [dbo].[USERS TYPES]([U_type_code])
go

alter table [LOG]
add
constraint fk_emp_id foreign key (emp_id) references [dbo].[EMPLOYEE] ([employee_pass_id])
go

alter table [LOG]
add
constraint fk_bus_id foreign key (bus_id) references [dbo].[BUSINESSES]([bus_id])
go

alter table [LOG]
add
constraint fk_uid foreign key ([uid]) references [dbo].[USERS] ([uid])
go

alter table [dbo].[BUS_CONTR]
add
constraint fk_bussin_id foreign key (bus_id) references [dbo].[BUSINESSES]([bus_id])
go

alter table [dbo].[BUS_CONTR]
add
constraint fk_contract_id foreign key ([contract_code]) references [dbo].[CONTRACTS] ([contract_code])
go

alter table [dbo].[CONTRACTS]
add
constraint fk_contract_type foreign key (contype_id) references CONTRACT_TYPE (contype_id)
go

alter table [dbo].[EMPLOYEE]
add
constraint fk_city_id foreign key ([add_city]) references [dbo].[CITY] ([ID])
go

alter table [dbo].[BUSINESSES]
add
constraint fk_cityb_id foreign key ([add_city]) references [dbo].[CITY] ([ID])
go

--alter table EMP_DOCS
--add
--constraint fk_em_id foreign key (emp_id) references [dbo].[EMPLOYEE] ([employee_pass_id])
--go

--alter table EMP_DOCS
--add
--constraint fk_doc_id foreign key (doc_id) references DOCS (doc_id)
--go

alter table DOCS
add
constraint fk_doc_type foreign key (doctype_id) references  DOC_TYPE (doctype_id)
go

alter table [dbo].[EMP_DIS_REASON]
add
constraint fk_dr_did foreign key ([did]) references [dbo].[DISABLE_REASON]  ([did])
go

alter table [dbo].[EMP_DIS_REASON]
add
constraint fk_ds_eis foreign key ([emp_id]) references [dbo].[EMPLOYEE] ([employee_pass_id])
go

alter table [dbo].[employee in dep]
add
constraint fk_dep foreign key (department_code) references [dbo].[DEPARTMENT_TYPE] (department_code)
go
alter table [dbo].[employee in dep]
add
constraint fk_dep_emp foreign key (employee_pass_id) references [dbo].[EMPLOYEE] (employee_pass_id)
go  


ALTER TABLE EMPLOYEE
drop COLUMN department_code 
go

ALTER TABLE EMPLOYEE
ADD food_incloud bit
go

ALTER TABLE EMPLOYEE
ADD food_pay int
go

ALTER TABLE EMPLOYEE
ADD monthly_rent int
go



alter table DOCS
Add emp_id nvarchar(30)
go
alter table DOCS
add
constraint fk_emp_doc foreign key (emp_id) references [dbo].[EMPLOYEE] (employee_pass_id)
go

alter table [dbo].[BUSINESSES]
add
constraint fk_dep foreign key ([department_code]) references [dbo].[DEPARTMENT_TYPE]([department_code])
go

ALTER TABLE EMPLOYEE
ADD final_bill bit
go




----------------------------------INSERT CITIES--------------------------------------
INSERT INTO CITY (CITYName) Values ('אבן יהודה');
INSERT INTO CITY (CITYName) Values ('אופקים');
INSERT INTO CITY (CITYName) Values ('אור הנר');
INSERT INTO CITY (CITYName) Values ('אור יהודה');
INSERT INTO CITY (CITYName) Values ('אזור');
INSERT INTO CITY (CITYName) Values ('אילת');
INSERT INTO CITY (CITYName) Values ('אמירים');
INSERT INTO CITY (CITYName) Values ('אפרת');
INSERT INTO CITY (CITYName) Values ('אריאל');
INSERT INTO CITY (CITYName) Values ('אשדוד');
INSERT INTO CITY (CITYName) Values ('אשקלון');
INSERT INTO CITY (CITYName) Values ('באר יעקב');
INSERT INTO CITY (CITYName) Values ('באר שבע');
INSERT INTO CITY (CITYName) Values ('בית דגן');
INSERT INTO CITY (CITYName) Values ('בית שאן');
INSERT INTO CITY (CITYName) Values ('בית שמש');
INSERT INTO CITY (CITYName) Values ('בית שערים');
INSERT INTO CITY (CITYName) Values ('בני ברק');
INSERT INTO CITY (CITYName) Values ('בנימינה');
INSERT INTO CITY (CITYName) Values ('בת ים');
INSERT INTO CITY (CITYName) Values ('גבעת סביון');
INSERT INTO CITY (CITYName) Values ('גבעת שמואל');
INSERT INTO CITY (CITYName) Values ('גבעתיים');
INSERT INTO CITY (CITYName) Values ('גדרה');
INSERT INTO CITY (CITYName) Values ('גלעד');
INSERT INTO CITY (CITYName) Values ('גן יבנה');
INSERT INTO CITY (CITYName) Values ('גני תקוה');
INSERT INTO CITY (CITYName) Values ('הוד השרון');
INSERT INTO CITY (CITYName) Values ('הרצליה');
INSERT INTO CITY (CITYName) Values ('זכרון יעקב');
INSERT INTO CITY (CITYName) Values ('חדרה');
INSERT INTO CITY (CITYName) Values ('חולון');
INSERT INTO CITY (CITYName) Values ('חיפה');
INSERT INTO CITY (CITYName) Values ('חצור הגלילית');
INSERT INTO CITY (CITYName) Values ('טבעון');
INSERT INTO CITY (CITYName) Values ('טבריה');
INSERT INTO CITY (CITYName) Values ('טירת הכרמל');
INSERT INTO CITY (CITYName) Values ('יבנה');
INSERT INTO CITY (CITYName) Values ('יהוד');
INSERT INTO CITY (CITYName) Values ('ים המלח');
INSERT INTO CITY (CITYName) Values ('יפו');
INSERT INTO CITY (CITYName) Values ('יקנעם עילית');
INSERT INTO CITY (CITYName) Values ('ירוחם');
INSERT INTO CITY (CITYName) Values ('ירושלים');
INSERT INTO CITY (CITYName) Values ('כוכב יאיר');
INSERT INTO CITY (CITYName) Values ('כפר אזר');
INSERT INTO CITY (CITYName) Values ('כפר ורדים');
INSERT INTO CITY (CITYName) Values ('כפר מל"ל');
INSERT INTO CITY (CITYName) Values ('כפר סבא');
INSERT INTO CITY (CITYName) Values ('כפר שמריהו');
INSERT INTO CITY (CITYName) Values ('כפר תבור');
INSERT INTO CITY (CITYName) Values ('כרכור');
INSERT INTO CITY (CITYName) Values ('כרמיאל');
INSERT INTO CITY (CITYName) Values ('לוד');
INSERT INTO CITY (CITYName) Values ('לפיד');
INSERT INTO CITY (CITYName) Values ('מבשרת ציון');
INSERT INTO CITY (CITYName) Values ('מגדל');
INSERT INTO CITY (CITYName) Values ('מגדל העמק');
INSERT INTO CITY (CITYName) Values ('מודיעין');
INSERT INTO CITY (CITYName) Values ('מטולה');
INSERT INTO CITY (CITYName) Values ('מכבים');
INSERT INTO CITY (CITYName) Values ('מכמורת');
INSERT INTO CITY (CITYName) Values ('מפלסים');
INSERT INTO CITY (CITYName) Values ('מצפה רמון');
INSERT INTO CITY (CITYName) Values ('מקווה ישראל');
INSERT INTO CITY (CITYName) Values ('נהריה');
INSERT INTO CITY (CITYName) Values ('נווה אור');
INSERT INTO CITY (CITYName) Values ('נווה איתן');
INSERT INTO CITY (CITYName) Values ('ניר ח"ן');
INSERT INTO CITY (CITYName) Values ('נס ציונה');
INSERT INTO CITY (CITYName) Values ('נען');
INSERT INTO CITY (CITYName) Values ('נצרת');
INSERT INTO CITY (CITYName) Values ('נצרת עילית');
INSERT INTO CITY (CITYName) Values ('נתיב הל"ה');
INSERT INTO CITY (CITYName) Values ('נתניה');
INSERT INTO CITY (CITYName) Values ('סביון');
INSERT INTO CITY (CITYName) Values ('עכו');
INSERT INTO CITY (CITYName) Values ('עפולה');
INSERT INTO CITY (CITYName) Values ('ערד');
INSERT INTO CITY (CITYName) Values ('עתלית');
INSERT INTO CITY (CITYName) Values ('פרדס חנה');
INSERT INTO CITY (CITYName) Values ('פתח-תקוה');
INSERT INTO CITY (CITYName) Values ('צור הדסה');
INSERT INTO CITY (CITYName) Values ('צורעה');
INSERT INTO CITY (CITYName) Values ('צפת');
INSERT INTO CITY (CITYName) Values ('קדימה');
INSERT INTO CITY (CITYName) Values ('קיבוץ אורטל');
INSERT INTO CITY (CITYName) Values ('קיבוץ נחל עוז');
INSERT INTO CITY (CITYName) Values ('קיבוץ עלומים');
INSERT INTO CITY (CITYName) Values ('קיסריה');
INSERT INTO CITY (CITYName) Values ('קצרין');
INSERT INTO CITY (CITYName) Values ('קרית אונו');
INSERT INTO CITY (CITYName) Values ('קרית אתא');
INSERT INTO CITY (CITYName) Values ('קרית ביאליק');
INSERT INTO CITY (CITYName) Values ('קרית גת');
INSERT INTO CITY (CITYName) Values ('קרית מוצקין');
INSERT INTO CITY (CITYName) Values ('קרית שמונה');
INSERT INTO CITY (CITYName) Values ('ראש העין');
INSERT INTO CITY (CITYName) Values ('ראש פינה');
INSERT INTO CITY (CITYName) Values ('ראשון לציון');
INSERT INTO CITY (CITYName) Values ('רחובות');
INSERT INTO CITY (CITYName) Values ('רמלה');
INSERT INTO CITY (CITYName) Values ('רמת אפעל');
INSERT INTO CITY (CITYName) Values ('רמת השרון');
INSERT INTO CITY (CITYName) Values ('רמת ישי');
INSERT INTO CITY (CITYName) Values ('רמת רזיאל');
INSERT INTO CITY (CITYName) Values ('רמת-גן');
INSERT INTO CITY (CITYName) Values ('רעננה');
INSERT INTO CITY (CITYName) Values ('שדרות');
INSERT INTO CITY (CITYName) Values ('שוהם');
INSERT INTO CITY (CITYName) Values ('שילה');
INSERT INTO CITY (CITYName) Values ('תל-אביב');


---------INSERT COUNRIEES-------------------------------------------------------



-------INSERT OCCUPATION-------------------------------------------------------

-------INSERT family status----------------------------------------------------


------------------VIEWS-------------------------
CREATE VIEW USER_V1
AS
SELECT        dbo.USERS.*, dbo.[USERS TYPES].U_type_name
FROM            dbo.USERS INNER JOIN
                         dbo.[USERS TYPES] ON dbo.USERS.U_type_code = dbo.[USERS TYPES].U_type_code
go
--create view v_newEmp
--as
--SELECT        dbo.[employee in business].employee_pass_id, dbo.EMPLOYEE.fname, dbo.EMPLOYEE.lname, dbo.EMPLOYEE.michpal_id, dbo.BUSINESSES.bus_name, dbo.EMPLOYEE.insurance, dbo.EMPLOYEE.il_citizen
--FROM            dbo.BUSINESSES INNER JOIN
--                         dbo.[employee in business] ON dbo.BUSINESSES.bus_id = dbo.[employee in business].bus_id INNER JOIN
--                         dbo.EMPLOYEE ON dbo.[employee in business].employee_pass_id = dbo.EMPLOYEE.employee_pass_id
--where (dbo.EMPLOYEE.il_citizen = 0 and  dbo.EMPLOYEE.insurance = 0)or (dbo.EMPLOYEE.il_citizen = 1 and dbo.EMPLOYEE.michpal_id = 0)
--go

create view v_newEmp
as
SELECT        dbo.[EMPLOYEE].employee_pass_id, dbo.EMPLOYEE.fname, dbo.EMPLOYEE.lname, dbo.EMPLOYEE.michpal_id,dbo.BUSINESSES.bus_name,  dbo.EMPLOYEE.insurance, dbo.EMPLOYEE.il_citizen, 
                         dbo.EMPLOYEE.active
FROM            dbo.BUSINESSES INNER JOIN
                         dbo.[employee in business] ON dbo.BUSINESSES.bus_id = dbo.[employee in business].bus_id INNER JOIN
                         dbo.EMPLOYEE ON dbo.[employee in business].employee_pass_id = dbo.EMPLOYEE.employee_pass_id
where  dbo.EMPLOYEE.active = 1 and [employee in business].end_date is null and ((dbo.EMPLOYEE.il_citizen = 0 and ( dbo.EMPLOYEE.insurance = 0 or dbo.EMPLOYEE.michpal_id = 0))or (dbo.EMPLOYEE.il_citizen = 1 and dbo.EMPLOYEE.michpal_id = 0))-- or (dbo.EMPLOYEE.il_citizen = 0 and  dbo.EMPLOYEE.insurance = 0))
go

--חידושי ויזה ושליחת אסמס
create VIEW v_ex_visa_date
as
SELECT        dbo.EMPLOYEE.employee_pass_id, dbo.EMPLOYEE.lname, dbo.EMPLOYEE.fname, dbo.EMPLOYEE.michpal_id, dbo.DOCS.ex_date, dbo.EMPLOYEE.phone
FROM            dbo.DOCS INNER JOIN
                         dbo.EMPLOYEE ON dbo.DOCS.emp_id = dbo.EMPLOYEE.employee_pass_id
						  where dbo.EMPLOYEE.[active]='true' and ( dbo.DOCS.ex_date<=DATEADD(day, DATEDIFF(day,0,GETDATE()),0) AND dbo.DOCS.[active]='true' and [doctype_id]='1')
						  go

create view v_nobusiness
as
SELECT        dbo.EMPLOYEE.*, dbo.BUSINESSES.bus_name
FROM            dbo.BUSINESSES INNER JOIN
                         dbo.[employee in business] ON dbo.BUSINESSES.bus_id = dbo.[employee in business].bus_id INNER JOIN
                         dbo.EMPLOYEE ON dbo.[employee in business].employee_pass_id = dbo.EMPLOYEE.employee_pass_id
						 where dbo.[employee in business].[bus_id] = 0 and  [end_date] is null
						 go

select * from v_nobusiness
go
------------
create view v_emp_no_busi_dash
as
SELECT        dbo.EMPLOYEE.employee_pass_id, dbo.EMPLOYEE.lname, dbo.EMPLOYEE.fname, dbo.EMPLOYEE.birthday, dbo.EMPLOYEE.gender, dbo.EMPLOYEE.Picture, dbo.EMPLOYEE.origin_country, dbo.EMPLOYEE.il_citizen, 
                         dbo.EMPLOYEE.add_city, dbo.EMPLOYEE.[add], dbo.EMPLOYEE.add_num, dbo.EMPLOYEE.phone, dbo.EMPLOYEE.com_app, dbo.EMPLOYEE.michpal_id, dbo.EMPLOYEE.insurance, dbo.EMPLOYEE.com_insurance, 
                         dbo.EMPLOYEE.fam_stat_code, dbo.EMPLOYEE.salary_hour, dbo.EMPLOYEE.salary_overtime, dbo.EMPLOYEE.salary_trans, dbo.EMPLOYEE.day_off_id, dbo.EMPLOYEE.sabatical, dbo.EMPLOYEE.occupation_code, 
                         dbo.EMPLOYEE.active, dbo.EMPLOYEE.disable_reason, dbo.EMPLOYEE.food_incloud, dbo.EMPLOYEE.food_pay, dbo.EMPLOYEE.monthly_rent, dbo.BUSINESSES.bus_name, 
                         dbo.[employee in business].[start_date] , dbo.[employee in business].end_date,DATEDIFF(DAY,dbo.[employee in business].[start_date],DATEADD(day, DATEDIFF(day, 0, GETDATE()), 0)) as daysPass
FROM				     dbo.BUSINESSES INNER JOIN
                         dbo.[employee in business] ON dbo.BUSINESSES.bus_id = dbo.[employee in business].bus_id INNER JOIN
                         dbo.EMPLOYEE ON dbo.[employee in business].employee_pass_id = dbo.EMPLOYEE.employee_pass_id
						 where dbo.EMPLOYEE.active = 'True' and( dbo.[employee in business].bus_id = 0 and dbo.[employee in business].end_date is null)-- and max(dbo.[employee in business].end_date)
go
----------------------------------------------------------------------------------
alter VIEW v_emp_not_active
as
SELECT        dbo.EMPLOYEE.employee_pass_id, dbo.EMPLOYEE.lname, dbo.EMPLOYEE.fname, dbo.EMPLOYEE.phone, dbo.EMPLOYEE.michpal_id, dbo.EMPLOYEE.active, dbo.BUSINESSES.bus_name, dbo.DISABLE_REASON.d_name, 
                         dbo.[DOCS].ex_date
FROM            dbo.[employee in business] INNER JOIN
                         dbo.EMPLOYEE ON dbo.[employee in business].employee_pass_id = dbo.EMPLOYEE.employee_pass_id INNER JOIN
                         dbo.EMP_DIS_REASON ON dbo.EMPLOYEE.employee_pass_id = dbo.EMP_DIS_REASON.emp_id INNER JOIN
                         dbo.DISABLE_REASON ON dbo.EMP_DIS_REASON.did = dbo.DISABLE_REASON.did INNER JOIN
                         dbo.BUSINESSES ON dbo.[employee in business].bus_id = dbo.BUSINESSES.bus_id left JOIN
						  dbo.DOCS ON dbo.EMPLOYEE.employee_pass_id = dbo.DOCS.emp_id
						  WHERE        ((dbo.EMPLOYEE.active = 'false') AND (dbo.[employee in business].end_date <= DATEADD(day, DATEDIFF(day, 0, GETDATE()), 0)))and dbo.DOCS.ex_date is not null and (dbo.EMPLOYEE.com_insurance = 'true'  or dbo.EMPLOYEE.com_app = 'true')

go

alter VIEW v_businessTable
as
SELECT        dbo.BUSINESSES.*, dbo.[BUSINESS TYPE].bus_type_name, dbo.DEPARTMENT_TYPE.department_name
FROM            dbo.[BUSINESS TYPE] INNER JOIN
                         dbo.BUSINESSES ON dbo.[BUSINESS TYPE].bus_type_code = dbo.BUSINESSES.bus_type_code INNER JOIN
                         dbo.DEPARTMENT_TYPE ON dbo.BUSINESSES.department_code = dbo.DEPARTMENT_TYPE.department_code
						 go

						 
select*from v_businessTable
--as
--SELECT         dbo.EMPLOYEE.employee_pass_id, min(dbo.EMPLOYEE.lname) as lname , min( dbo.EMPLOYEE.fname)as fname, min(cast( dbo.EMPLOYEE.com_app as int)) as com_app, min(cast( dbo.EMPLOYEE.com_insurance as int)) as com_insurance,  min(cast( dbo.EMPLOYEE.active as int)) as active, 
--                          min(dbo.EMPLOYEE.michpal_id) as michpal_id, min(dbo.EMPLOYEE.phone) as phone, min( dbo.BUSINESSES.bus_name) as bus_name, max( dbo.DOCS.ex_date) as ex_date, min(disable_reason.d_name) as d_name 
--						 FROM            dbo.DISABLE_REASON INNER JOIN
--                         dbo.EMP_DIS_REASON ON dbo.DISABLE_REASON.did = dbo.EMP_DIS_REASON.did INNER JOIN
--                         dbo.EMPLOYEE ON dbo.EMP_DIS_REASON.emp_id = dbo.EMPLOYEE.employee_pass_id INNER JOIN
--                         dbo.[employee in business] ON dbo.EMPLOYEE.employee_pass_id = dbo.[employee in business].employee_pass_id INNER JOIN
--                         dbo.BUSINESSES ON dbo.[employee in business].bus_id = dbo.BUSINESSES.bus_id INNER JOIN
--                         dbo.DOCS ON dbo.EMPLOYEE.employee_pass_id = dbo.DOCS.emp_id
--						 WHERE        ((dbo.EMPLOYEE.active = 'false') AND (dbo.[employee in business].end_date <= DATEADD(day, DATEDIFF(day, 0, GETDATE()), 0))) and (dbo.EMPLOYEE.com_insurance = 'true'  or dbo.EMPLOYEE.com_app = 'true')
--						group by dbo.EMPLOYEE.employee_pass_id
--go

      
----------------------------------------------------------------------------------

select * from v_emp_not_active
go
--היסטוריית תעסוקה
create view history
as
SELECT        dbo.EMPLOYEE.employee_pass_id, dbo.EMPLOYEE.lname, dbo.EMPLOYEE.fname, dbo.BUSINESSES.bus_name, dbo.[employee in business].start_date, dbo.[employee in business].end_date
FROM            dbo.BUSINESSES INNER JOIN
                         dbo.[employee in business] ON dbo.BUSINESSES.bus_id = dbo.[employee in business].bus_id INNER JOIN
                         dbo.EMPLOYEE ON dbo.[employee in business].employee_pass_id = dbo.EMPLOYEE.employee_pass_id
where  dbo.[employee in business].end_date is not null and dbo.BUSINESSES.bus_name != 'ללא ציוות'
go

--for update employee
create view fullEmp
as
SELECT        dbo.EMPLOYEE.*, dbo.[employee in business].bus_id
FROM            dbo.EMPLOYEE INNER JOIN
                         dbo.[employee in business] ON dbo.EMPLOYEE.employee_pass_id = dbo.[employee in business].employee_pass_id
						 where [employee in business].end_date is null
						 go
--for statistics
--new employee for today


CREATE TABLE DUAL
(
DUMMY VARCHAR(1)
)
GO
INSERT INTO DUAL (DUMMY)
VALUES ('X')
GO

create view v_s_totalNew
as
SELECT(
      SELECT COUNT(*)
	  FROM   dbo.EMPLOYEE
	  ) AS Total_Employees,
	  (SELECT COUNT(*)
	  FROM   [dbo].[v_newEmp]
	  ) AS total_new_emp
FROM dual
go


--employee Archive
create view v_emp_archive
as
SELECT        *
FROM            dbo.EMPLOYEE
WHERE        (active = 'false')
go

--business Archive
--create view v_busi_archive
--as
--SELECT        *
--FROM            dbo.BUSINESSES
--WHERE        (active = 'false')
--go

create view v_contacts
as
SELECT        dbo.[contacts to business].contact_id, dbo.[contacts to business].contact_name, dbo.[contacts to business].phone, dbo.[contacts to business].email, dbo.[ROLES OF CONTACTS].role_name, dbo.[ROLES OF CONTACTS].role_desc,
                          dbo.BUSINESSES.bus_name, dbo.BUSINESSES.bus_id, dbo.[ROLES OF CONTACTS].role_id
FROM            dbo.BUSINESSES INNER JOIN
                         dbo.[contacts in business] ON dbo.BUSINESSES.bus_id = dbo.[contacts in business].bus_id INNER JOIN
                         dbo.[contacts to business] ON dbo.[contacts in business].contact_id = dbo.[contacts to business].contact_id INNER JOIN
                         dbo.[ROLES OF CONTACTS] ON dbo.[contacts to business].role_id = dbo.[ROLES OF CONTACTS].role_id
						 go

						 -----------------------------------
				-------------		 STATISTICSPAGE      -------------------
				-- Record with the earliest date per empId,for growth by yer on employees.
create view v_s_empGrowth
as
SELECT
 [employee_pass_id],  [start_date]
  
FROM [dbo].[employee in business] AS e
WHERE
   e.[start_date] =
   (
   SELECT TOP (1)
      e2.[start_date]
   FROM [dbo].[employee in business] AS e2
   WHERE
      e2.[employee_pass_id] = e.[employee_pass_id]
   ORDER BY
      e2.[start_date] ASC
   )
 go

 alter view v_s_Growth2016
 as
 select  count([employee_pass_id]) as num from v_s_empGrowth where YEAR (  [start_date]) = '2016'
 go

alter view v_s_Growth2017
 as
 select  count([employee_pass_id]) as num from v_s_empGrowth where YEAR (  [start_date]) = '2017'
 go

alter view v_s_Growth2018
 as
 select DISTINCT count([employee_pass_id])  as num from v_s_empGrowth where YEAR (  [start_date]) = '2018'
 go




--([dbo].[v_s_Growth2017])-[dbo].[v_s_Growth2016]/[dbo].[v_s_Growth2016]--שנת 2017 לעומת 2016
go
--([dbo].[v_s_Growth2018]-[dbo].[v_s_Growth2017])/[dbo].[v_s_Growth2017]--שנת 2018 לעומת 2017
go

--UNION--
 create view v_growth_by_months_on_emp
 as
SELECT(
      select  count([employee_pass_id]) as num from v_s_empGrowth where month ( [start_date]) = '1'
	  ) AS 'Junuary',
	  ( select  count([employee_pass_id]) as num from v_s_empGrowth where month ( [start_date]) = '2'
	  ) AS 'February',
		  ( select  count([employee_pass_id]) as num from v_s_empGrowth where month ( [start_date]) = '3'
	  ) AS 'March',
	      (  select  count([employee_pass_id]) as num from v_s_empGrowth where month ( [start_date]) = '4'
	  ) AS 'April',
	  ( select  count([employee_pass_id]) as num from v_s_empGrowth where month ( [start_date]) = '5'
	  ) AS 'May',
		  ( select  count([employee_pass_id]) as num from v_s_empGrowth where month ( [start_date]) = '6'
	  ) AS 'June',
	   (     select  count([employee_pass_id]) as num from v_s_empGrowth where month ( [start_date]) = '7'
	  ) AS 'July',
	  ( select  count([employee_pass_id]) as num from v_s_empGrowth where month ( [start_date]) = '8'
	  ) AS 'August',
		  ( select  count([employee_pass_id]) as num from v_s_empGrowth where month ( [start_date]) = '9'
	  ) AS 'September', 
	   (    select  count([employee_pass_id]) as num from v_s_empGrowth where month ( [start_date]) = '10'
	  ) AS 'October',
	  ( select  count([employee_pass_id]) as num from v_s_empGrowth where month ( [start_date]) = '11'
	  ) AS 'November',
		  ( select  count([employee_pass_id]) as num from v_s_empGrowth where month ( [start_date]) = '12'
	  ) AS 'December'
FROM dual
go



---- Record with the earliest date per empId,for growth by year on Business.
--create view v_s_BusinessGrowth
--as
--SELECT
-- [bus_id], [commence_date]
  
--FROM [dbo].[BUSINESSES] AS e
--WHERE
--   e.[commence_date] =
--   (
--   SELECT TOP (1)
--      e2.[commence_date]
--   FROM [dbo].[BUSINESSES] AS e2
--   WHERE
--      e2.[bus_id] = e.[bus_id]
--   ORDER BY
--      e2.[commence_date] ASC
--   )
-- go




-- create view v_growth_by_years_on_busi
-- as
--SELECT(
--      select  count([bus_id]) as num from [dbo].[BUSINESSES] where year ( [commence_date]) = '2016'
--	  ) AS 'e2016',
--	  (   select  count([bus_id]) as num from [dbo].[BUSINESSES] where year ( [commence_date]) = '2017'
--	  ) AS 'e2017',
--	  (   select  count([bus_id]) as num from [dbo].[BUSINESSES] where year ( [commence_date]) = '2018'
--	  ) AS 'e2018'
--	  FROM dual
--go




-- create view Q1
-- as
--SELECT(
--      select  count([bus_id]) as num from [dbo].[BUSINESSES] where month ([commence_date] ) = '1' and year([commence_date])='2016'--and month ([commence_date] )='2' and month ([commence_date] )='3'
--	  ) AS '1',
--	  (
--      select  count([bus_id]) as num from [dbo].[BUSINESSES] where month ([commence_date] ) = '2' and year([commence_date])='2016'--and month ([commence_date] )='2' and month ([commence_date] )='3'
--	  ) AS '2',
--	  (
--      select  count([bus_id]) as num from [dbo].[BUSINESSES] where month ([commence_date] ) = '3' and year([commence_date])='2016'--and month ([commence_date] )='2' and month ([commence_date] )='3'
--	  ) AS '3'
--FROM dual
--go

--create view e2016_Q1
-- as
--SELECT(
--      select [1]+[2]+[3] as Q1 from [dbo].[Q1] --where month ([commence_date] ) = '1'--and month ([commence_date] )='2' and month ([commence_date] )='3'
--	  ) AS 'Q1'
--FROM dual
--go

-- create view Q2
-- as
--SELECT(
--      select  count([bus_id]) as num from [dbo].[BUSINESSES] where month ([commence_date] ) = '4' and year([commence_date])='2016'--and month ([commence_date] )='2' and month ([commence_date] )='3'
--	  ) AS '4',
--	  (
--      select  count([bus_id]) as num from [dbo].[BUSINESSES] where month ([commence_date] ) = '5' and year([commence_date])='2016'--and month ([commence_date] )='2' and month ([commence_date] )='3'
--	  ) AS '5',
--	  (
--      select  count([bus_id]) as num from [dbo].[BUSINESSES] where month ([commence_date] ) = '6' and year([commence_date])='2016'--and month ([commence_date] )='2' and month ([commence_date] )='3'
--	  ) AS '6'
--FROM dual
--go

--alter view e2016_Q2
-- as
--SELECT(
--      select [4]+[5]+[6] as Q2 from [dbo].[Q2] --where month ([commence_date] ) = '1'--and month ([commence_date] )='2' and month ([commence_date] )='3'
--	  ) AS 'Q2'
--FROM dual
--go


-- create view Q3
-- as
--SELECT(
--      select  count([bus_id]) as num from [dbo].[BUSINESSES] where month ([commence_date] ) = '7' and year([commence_date])='2016'--and month ([commence_date] )='2' and month ([commence_date] )='3'
--	  ) AS '7',
--	  (
--      select  count([bus_id]) as num from [dbo].[BUSINESSES] where month ([commence_date] ) = '8' and year([commence_date])='2016'--and month ([commence_date] )='2' and month ([commence_date] )='3'
--	  ) AS '8',
--	  (
--      select  count([bus_id]) as num from [dbo].[BUSINESSES] where month ([commence_date] ) = '9' and year([commence_date])='2016'--and month ([commence_date] )='2' and month ([commence_date] )='3'
--	  ) AS '9'
--FROM dual
--go

--create view e2016_Q3
-- as
--SELECT(
--      select [7]+[8]+[9] as Q3 from [dbo].[Q3] --where month ([commence_date] ) = '1'--and month ([commence_date] )='2' and month ([commence_date] )='3'
--	  ) AS 'Q3'
--FROM dual
--go

--employee yearly growth
create VIEW V_employee_yearly_growth
as
SELECT DATEPART(YEAR,[start_date]) as [start_Year],
COUNT(1) as [employeeCount]
FROM [dbo].[employee in business]
GROUP BY DATEPART(YEAR,[start_date])
go

--employee monthly growth
alter VIEW [V_employee_monthly_growth]
as
SELECT DATEPART(YEAR,[start_date]) as [start_year_for_month],
DATEPART(MONTH,[start_date]) as Months,
COUNT(1) as [employeeCountMonth]
FROM [dbo].[employee in business]
--where year([start_date]) = YEAR(getdate())--only current year
GROUP BY DATEPART(YEAR,[start_date]),DatePART(month,[start_date])
--ORDER BY 1,2,3
go

--business yearly growth
alter VIEW V_business_yearly_growth
as
SELECT DATEPART(YEAR,commence_date) as [Year],
COUNT(1) as [businessCount]
FROM [dbo].[BUSINESSES]
GROUP BY DATEPART(YEAR,commence_date)
go

--business QUARTER growth
alter VIEW [V_business_QUARTER_growth]
as
SELECT DATEPART(YEAR,commence_date) as [commence_date_Year],
 DATEPART(QUARTER,commence_date) as [Quarter], COUNT(1) as [businessCountQuarter]
FROM [dbo].[BUSINESSES]
where year(commence_date) = YEAR(getdate())
GROUP BY DATEPART(YEAR,commence_date),DatePART(QUARTER,commence_date)
--ORDER BY 1,2
go


INSERT INTO EMPLOYEE (employee_pass_id,lname,fname,birthday,gender,Picture,origin_country,il_citizen,add_city,add,add_num,phone,com_app,michpal_id,insurance,com_insurance,fam_stat_code,salary_hour,salary_overtime,salary_trans,day_off_id,sabatical, occupation_code,active,disable_reason,food_incloud,food_pay,monthly_rent,final_bill) 
Values                                      ('231dscsd', 'dfsvs' ,'sdfds', '1989-06-13', 'False', '', '1', 'False', '1', 'asdf', '2', '9876543', 'True', '0', 'False', 'False', '2', '23', '23', '23', '7', '7', '1', 'True', '','True','23','0','false')


go

----Smart Element--------------

create table rolling
( emp_id float primary key not null,
date date not null
)
go
drop table [dbo].[rolling]

If Object_ID('rolling','U') Is Not Null Drop Table [dbo].[rolling];
Go

Select  count( distinct employee_pass_id) [NumOfEmp],
      [start_date]
Into   [dbo].[rolling]
From    [dbo].[employee in business]
group by [start_date]
go



select (start_date), count([employee_pass_id])
from [dbo].[employee in business]
group by (start_date)







--	;WITH CTE_MA AS
--    (
--        SELECT
--		 month('1'+[Month]+'00') as [Month],
--		  [employeeCountMonth]

--        FROM before_rolling_running
--    )
--SELECT
--    T0.[Month]
--    ,AVG(T1.[employeeCountMonth]) as [employeeRunningCount]
--FROM
--    CTE_MA AS T0
--	LEFT OUTER JOIN
--    CTE_MA AS T1
--ON

--   month( T1.[Month] )<= month( T0.[Month])
--AND
--   month( T1.[Month]) >= month( T0.[Month]) -11

--GROUP BY
--    T0.[Month]
--    ,T0.[employeeCountMonth]
----	order by  month( T0.[Month])
--	go

--	Select * From [dbo].[before_rolling_running];




create view LeavingCompany
as
SELECT      distinct dbo.[employee in business].employee_pass_id , dbo.[employee in business].end_date
FROM            dbo.[employee in business] INNER JOIN
                         dbo.EMPLOYEE ON dbo.[employee in business].employee_pass_id = dbo.EMPLOYEE.employee_pass_id
						 where active='0' and end_date is not null
						 go

						 create view [V_employee_monthly_leaving]
						 as
SELECT *
FROM (SELECT YEAR(end_date) [Year], 
       DATENAME(MONTH, end_date) [Month], 
       COUNT(1) [employeeCountMonth]

      FROM LeavingCompany 
      GROUP BY YEAR(end_date), 
      DATENAME(MONTH, end_date)) AS MontlyemployeeData
PIVOT( SUM([employeeCountMonth])   
    FOR Month IN ([January],[February],[March],[April],[May],
    [June],[July],[August],[September],[October],[November],
    [December])) AS MNamePivot
GO



create view monthly_growth_Againts_monthly_leaving
as
SELECT      dbo.V_employee_monthly_growth.Year,sum( dbo.V_employee_monthly_growth.January-  dbo.V_employee_monthly_leaving.January) as jan,isnull(sum( dbo.V_employee_monthly_growth.February-  dbo.V_employee_monthly_leaving.February),0) as fab,isnull(sum( dbo.V_employee_monthly_growth.March-  dbo.V_employee_monthly_leaving.March),0) as mar,isnull(sum( dbo.V_employee_monthly_growth.April-  dbo.V_employee_monthly_leaving.April),0) as apr,isnull(sum( dbo.V_employee_monthly_growth.May-  dbo.V_employee_monthly_leaving.May),0) as may,isnull(sum( dbo.V_employee_monthly_growth.June-  dbo.V_employee_monthly_leaving.June),0) as june,isnull(sum( dbo.V_employee_monthly_growth.July-  isnull(dbo.V_employee_monthly_leaving.July,0)),0) as july,isnull(sum( dbo.V_employee_monthly_growth.August-  dbo.V_employee_monthly_leaving.August),0) as Aug,isnull(sum( dbo.V_employee_monthly_growth.September-  dbo.V_employee_monthly_leaving.September),0) as Sep,isnull(sum( dbo.V_employee_monthly_growth.October-  dbo.V_employee_monthly_leaving.October),0) as oct,isnull(sum( dbo.V_employee_monthly_growth.November-  dbo.V_employee_monthly_leaving.November),0) as nov,isnull(sum( dbo.V_employee_monthly_growth.December-  dbo.V_employee_monthly_leaving.December),0) as decm
FROM            dbo.V_employee_monthly_growth CROSS JOIN
                         dbo.V_employee_monthly_leaving
						 group by dbo.V_employee_monthly_growth.Year
go

alter view TRY1
as

	  SELECT *
FROM (SELECT
       DATENAME(MONTH, [start_date]) [Month], 
       COUNT(1) [employeeCountMonth]

      FROM [dbo].[employee in business]
      GROUP BY  
      DATENAME(MONTH, [start_date])) AS MontlyemployeeData
	  go

	 alter view TRY2
as

	  SELECT *
FROM (SELECT 
       DATENAME(MONTH, end_date) [Month1], 
       COUNT(1) [employeeCountMonth1]

      FROM LeavingCompany 
      GROUP BY DATENAME(MONTH, end_date), 
      DATENAME(MONTH, end_date)) AS MontlyemployeeData



alter view final_calc
as
SELECT DISTINCT [Month],

CASE [Month] WHEN [Month1] 
 THEN [employeeCountMonth]-[employeeCountMonth1]
 ELSE [employeeCountMonth]
 END
 AS [employeeCountMonth]

FROM [dbo].[combine]
--
--group by [Month],[Month1]--,[employeeCountMonth]
--order by 
	go  

	create view before_rolling_running
	as
SELECT [Month] , min([employeeCountMonth]) as [employeeCountMonth]
  FROM final_calc
  GROUP BY [Month]



alter view combine
as
SELECT         dbo.TRY1.*,dbo.TRY2.*
FROM            dbo.TRY1 CROSS JOIN
                         dbo.TRY2
go





SELECT @@VERSION AS 'SQL Server Version'; 
go
create view SmartElement
as
With CTE
As
(
SELECT *
		, Row_Number() Over(Order by month('1'+[Month]+'00') ) As RowNum
FROM	[dbo].[before_rolling_running]
)
Select	month('1'+[Month]+'00') as [Month]
		, [employeeCountMonth],(	Select AVG([employeeCountMonth])
			From	CTE B
			Where	B.RowNum Between A.RowNum - 3 And A.RowNum
			) As Moving_AVG
		
		
From	CTE A

Select * From [dbo].[before_rolling_running];



