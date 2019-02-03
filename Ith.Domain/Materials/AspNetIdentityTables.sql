DROP TABLE IF EXISTS AspNetUserClaims; 
DROP TABLE IF EXISTS AspNetUserLogins;
DROP TABLE IF EXISTS AspNetUserRoles; 
DROP TABLE IF EXISTS AspNetRoles; 
DROP TABLE IF EXISTS AspNetUsers;
 
CREATE TABLE AspNetUsers 
( 
  Id nvarchar(128) NOT NULL, 
  Email nvarchar(256) NULL, 
  EmailConfirmed int NOT NULL, 
  PasswordHash nvarchar(max) NULL, 
  SecurityStamp nvarchar(max) NULL, 
  PhoneNumber nvarchar(max) NULL, 
  PhoneNumberConfirmed bit NOT NULL, 
  TwoFactorEnabled bit NOT NULL, 
  LockoutEndDateUtc datetime NULL, 
  LockoutEnabled bit NOT NULL, 
  AccessFailedCount int NOT NULL, 
  UserName nvarchar(256) NOT NULL
  PRIMARY KEY (Id) 
); 

ALTER TABLE AspNetUsers ADD Name nvarchar(256) NOT NULL;

CREATE TABLE AspNetUserClaims 
( 
  Id int NOT NULL AUTO_INCREMENT, 
  UserId nvarchar(128) NOT NULL, 
  ClaimType nvarchar(512) NULL, 
  ClaimValue nvarchar(512) NULL, 
  PRIMARY KEY (Id), 
  FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE 
); 

CREATE TABLE AspNetUserLogins 
( 
  LoginProvider nvarchar(128) NOT NULL, 
  ProviderKey nvarchar(128) NOT NULL, 
  UserId nvarchar(128) NOT NULL, 
  PRIMARY KEY (LoginProvider, ProviderKey, UserId), 
  FOREIGN KEY(UserId) REFERENCES AspNetUsers (Id) ON DELETE CASCADE 
); 

CREATE TABLE AspNetRoles 
( 
  Id nvarchar(128) NOT NULL, 
  Name nvarchar(256) NOT NULL, 
  Description nvarchar(512) NOT NULL,
  Discriminator nvarchar(128) NOT NULL,
  PRIMARY KEY (Id) 
); 
 
CREATE TABLE AspNetUserRoles 
( 
  UserId nvarchar(128) NOT NULL, 
  RoleId nvarchar(128) NOT NULL, 
  PRIMARY KEY (UserId, RoleId), 
  FOREIGN KEY(RoleId) REFERENCES AspNetRoles (Id) ON DELETE CASCADE, 
  FOREIGN KEY(UserId) REFERENCES AspNetUsers (Id) ON DELETE CASCADE 
); 