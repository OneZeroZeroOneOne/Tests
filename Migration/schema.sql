/*
 Navicat Premium Data Transfer

 Source Server         : tests
 Source Server Type    : PostgreSQL
 Source Server Version : 120005
 Source Host           : 104.248.250.163:5432
 Source Catalog        : postgres
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 120005
 File Encoding         : 65001

 Date: 14/12/2020 18:26:53
*/


-- ----------------------------
-- Sequence structure for Answer_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Answer_Id_seq";
CREATE SEQUENCE "public"."Answer_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for Employee_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Employee_Id_seq";
CREATE SEQUENCE "public"."Employee_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for LongevityType_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."LongevityType_Id_seq";
CREATE SEQUENCE "public"."LongevityType_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for QuestionType_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."QuestionType_Id_seq";
CREATE SEQUENCE "public"."QuestionType_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for Question_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Question_Id_seq";
CREATE SEQUENCE "public"."Question_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for Quiz_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Quiz_Id_seq";
CREATE SEQUENCE "public"."Quiz_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for Role_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Role_Id_seq";
CREATE SEQUENCE "public"."Role_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for Status_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Status_Id_seq";
CREATE SEQUENCE "public"."Status_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for SubscriptionType_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."SubscriptionType_Id_seq";
CREATE SEQUENCE "public"."SubscriptionType_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for Subscription_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Subscription_Id_seq";
CREATE SEQUENCE "public"."Subscription_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for UserAnswer_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."UserAnswer_Id_seq";
CREATE SEQUENCE "public"."UserAnswer_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for UserEmployee_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."UserEmployee_Id_seq";
CREATE SEQUENCE "public"."UserEmployee_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for UserQuiz_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."UserQuiz_Id_seq";
CREATE SEQUENCE "public"."UserQuiz_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for User_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."User_Id_seq";
CREATE SEQUENCE "public"."User_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Table structure for Answer
-- ----------------------------
DROP TABLE IF EXISTS "public"."Answer";
CREATE TABLE "public"."Answer" (
  "Id" int4 NOT NULL DEFAULT nextval('"Answer_Id_seq"'::regclass),
  "QuestionId" int4,
  "Text" text COLLATE "pg_catalog"."default",
  "CreateDateTime" timestamp(6)
)
;

-- ----------------------------
-- Table structure for AnswerTamplate
-- ----------------------------
DROP TABLE IF EXISTS "public"."AnswerTamplate";
CREATE TABLE "public"."AnswerTamplate" (
  "Id" int4 NOT NULL,
  "QuestionTamplateId" int4,
  "Text" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Table structure for Employee
-- ----------------------------
DROP TABLE IF EXISTS "public"."Employee";
CREATE TABLE "public"."Employee" (
  "Id" int4 NOT NULL DEFAULT nextval('"Employee_Id_seq"'::regclass),
  "Name" text COLLATE "pg_catalog"."default",
  "Soname" text COLLATE "pg_catalog"."default",
  "DateOfBirth" timestamp(6),
  "Gender" text COLLATE "pg_catalog"."default",
  "Position" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Table structure for JwtOptions
-- ----------------------------
DROP TABLE IF EXISTS "public"."JwtOptions";
CREATE TABLE "public"."JwtOptions" (
  "Issuer" text COLLATE "pg_catalog"."default",
  "Audience" text COLLATE "pg_catalog"."default",
  "Key" text COLLATE "pg_catalog"."default",
  "Lifetime" int4
)
;

-- ----------------------------
-- Table structure for LongevityType
-- ----------------------------
DROP TABLE IF EXISTS "public"."LongevityType";
CREATE TABLE "public"."LongevityType" (
  "Id" int4 NOT NULL DEFAULT nextval('"LongevityType_Id_seq"'::regclass),
  "LongevityValue" int4 NOT NULL,
  "LongevityMeasureName" text COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Table structure for Question
-- ----------------------------
DROP TABLE IF EXISTS "public"."Question";
CREATE TABLE "public"."Question" (
  "Id" int4 NOT NULL DEFAULT nextval('"Question_Id_seq"'::regclass),
  "QuizId" int4,
  "QuestionTypeId" int4,
  "Text" text COLLATE "pg_catalog"."default",
  "CreateDateTime" timestamp(6)
)
;

-- ----------------------------
-- Table structure for QuestionTemplate
-- ----------------------------
DROP TABLE IF EXISTS "public"."QuestionTemplate";
CREATE TABLE "public"."QuestionTemplate" (
  "Id" int4 NOT NULL,
  "Text" text COLLATE "pg_catalog"."default",
  "QuestionTypeId" int4
)
;

-- ----------------------------
-- Table structure for QuestionType
-- ----------------------------
DROP TABLE IF EXISTS "public"."QuestionType";
CREATE TABLE "public"."QuestionType" (
  "Id" int4 NOT NULL DEFAULT nextval('"QuestionType_Id_seq"'::regclass),
  "Title" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Table structure for Quiz
-- ----------------------------
DROP TABLE IF EXISTS "public"."Quiz";
CREATE TABLE "public"."Quiz" (
  "Id" int4 NOT NULL DEFAULT nextval('"Quiz_Id_seq"'::regclass),
  "CreateDateTime" timestamp(6),
  "StatusId" int4
)
;

-- ----------------------------
-- Table structure for Role
-- ----------------------------
DROP TABLE IF EXISTS "public"."Role";
CREATE TABLE "public"."Role" (
  "Id" int4 NOT NULL DEFAULT nextval('"Role_Id_seq"'::regclass),
  "Title" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Table structure for Status
-- ----------------------------
DROP TABLE IF EXISTS "public"."Status";
CREATE TABLE "public"."Status" (
  "Id" int4 NOT NULL DEFAULT nextval('"Status_Id_seq"'::regclass),
  "Title" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Table structure for Subscription
-- ----------------------------
DROP TABLE IF EXISTS "public"."Subscription";
CREATE TABLE "public"."Subscription" (
  "Id" int4 NOT NULL DEFAULT nextval('"Subscription_Id_seq"'::regclass),
  "UserId" int4 NOT NULL,
  "TypeId" int4 NOT NULL,
  "BeginDateTime" timestamp(6) NOT NULL,
  "EndDateTime" timestamp(6) NOT NULL,
  "CreatedDateTime" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "IsActive" bool NOT NULL
)
;

-- ----------------------------
-- Table structure for SubscriptionType
-- ----------------------------
DROP TABLE IF EXISTS "public"."SubscriptionType";
CREATE TABLE "public"."SubscriptionType" (
  "Id" int4 NOT NULL DEFAULT nextval('"SubscriptionType_Id_seq"'::regclass),
  "Description" text COLLATE "pg_catalog"."default" NOT NULL,
  "Price" numeric(10,2) NOT NULL,
  "LongevityTypeId" int4 NOT NULL,
  "Name" text COLLATE "pg_catalog"."default" NOT NULL,
  "AvailableTestAmount" int4 NOT NULL DEFAULT 1
)
;

-- ----------------------------
-- Table structure for User
-- ----------------------------
DROP TABLE IF EXISTS "public"."User";
CREATE TABLE "public"."User" (
  "Id" int4 NOT NULL DEFAULT nextval('"User_Id_seq"'::regclass),
  "Name" text COLLATE "pg_catalog"."default" NOT NULL,
  "RoleId" int4 NOT NULL,
  "CreateDateTime" timestamp(6) NOT NULL,
  "AvatarUrl" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Table structure for UserAnswer
-- ----------------------------
DROP TABLE IF EXISTS "public"."UserAnswer";
CREATE TABLE "public"."UserAnswer" (
  "Id" int4 NOT NULL DEFAULT nextval('"UserAnswer_Id_seq"'::regclass),
  "EmployeeId" int4,
  "QuizId" int4,
  "QuestionId" int4,
  "AnswerId" int4,
  "CreateDateTime" timestamp(6)
)
;

-- ----------------------------
-- Table structure for UserEmployee
-- ----------------------------
DROP TABLE IF EXISTS "public"."UserEmployee";
CREATE TABLE "public"."UserEmployee" (
  "Id" int4 NOT NULL DEFAULT nextval('"UserEmployee_Id_seq"'::regclass),
  "UserId" int4,
  "EmployeeId" int4
)
;

-- ----------------------------
-- Table structure for UserQuiz
-- ----------------------------
DROP TABLE IF EXISTS "public"."UserQuiz";
CREATE TABLE "public"."UserQuiz" (
  "Id" int4 NOT NULL DEFAULT nextval('"UserQuiz_Id_seq"'::regclass),
  "UserId" int4,
  "QuizId" int4,
  "EmployeeId" int4
)
;

-- ----------------------------
-- Table structure for UserSecurity
-- ----------------------------
DROP TABLE IF EXISTS "public"."UserSecurity";
CREATE TABLE "public"."UserSecurity" (
  "UserId" int4 NOT NULL,
  "Login" text COLLATE "pg_catalog"."default" NOT NULL,
  "Password" text COLLATE "pg_catalog"."default" NOT NULL,
  "Email" text COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Answer_Id_seq"
OWNED BY "public"."Answer"."Id";
SELECT setval('"public"."Answer_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Employee_Id_seq"
OWNED BY "public"."Employee"."Id";
SELECT setval('"public"."Employee_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."LongevityType_Id_seq"
OWNED BY "public"."LongevityType"."Id";
SELECT setval('"public"."LongevityType_Id_seq"', 3, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."QuestionType_Id_seq"
OWNED BY "public"."QuestionType"."Id";
SELECT setval('"public"."QuestionType_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Question_Id_seq"
OWNED BY "public"."Question"."Id";
SELECT setval('"public"."Question_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Quiz_Id_seq"
OWNED BY "public"."Quiz"."Id";
SELECT setval('"public"."Quiz_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Role_Id_seq"
OWNED BY "public"."Role"."Id";
SELECT setval('"public"."Role_Id_seq"', 3, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Status_Id_seq"
OWNED BY "public"."Status"."Id";
SELECT setval('"public"."Status_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."SubscriptionType_Id_seq"
OWNED BY "public"."SubscriptionType"."Id";
SELECT setval('"public"."SubscriptionType_Id_seq"', 4, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Subscription_Id_seq"
OWNED BY "public"."Subscription"."Id";
SELECT setval('"public"."Subscription_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."UserAnswer_Id_seq"
OWNED BY "public"."UserAnswer"."Id";
SELECT setval('"public"."UserAnswer_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."UserEmployee_Id_seq"
OWNED BY "public"."UserEmployee"."Id";
SELECT setval('"public"."UserEmployee_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."UserQuiz_Id_seq"
OWNED BY "public"."UserQuiz"."Id";
SELECT setval('"public"."UserQuiz_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."User_Id_seq"
OWNED BY "public"."User"."Id";
SELECT setval('"public"."User_Id_seq"', 35, true);

-- ----------------------------
-- Primary Key structure for table Answer
-- ----------------------------
ALTER TABLE "public"."Answer" ADD CONSTRAINT "Answer_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table AnswerTamplate
-- ----------------------------
ALTER TABLE "public"."AnswerTamplate" ADD CONSTRAINT "AnswerTamplate_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table Employee
-- ----------------------------
ALTER TABLE "public"."Employee" ADD CONSTRAINT "Employee_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table LongevityType
-- ----------------------------
ALTER TABLE "public"."LongevityType" ADD CONSTRAINT "LongevityType_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table Question
-- ----------------------------
ALTER TABLE "public"."Question" ADD CONSTRAINT "Question_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table QuestionTemplate
-- ----------------------------
ALTER TABLE "public"."QuestionTemplate" ADD CONSTRAINT "QuestionTemplate_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table QuestionType
-- ----------------------------
ALTER TABLE "public"."QuestionType" ADD CONSTRAINT "QuestionType_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table Quiz
-- ----------------------------
ALTER TABLE "public"."Quiz" ADD CONSTRAINT "Quiz_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table Role
-- ----------------------------
ALTER TABLE "public"."Role" ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table Status
-- ----------------------------
ALTER TABLE "public"."Status" ADD CONSTRAINT "Status_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table Subscription
-- ----------------------------
ALTER TABLE "public"."Subscription" ADD CONSTRAINT "Subscription_pkey" PRIMARY KEY ("Id", "UserId");

-- ----------------------------
-- Primary Key structure for table SubscriptionType
-- ----------------------------
ALTER TABLE "public"."SubscriptionType" ADD CONSTRAINT "SubscriptionType_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table User
-- ----------------------------
ALTER TABLE "public"."User" ADD CONSTRAINT "User_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table UserAnswer
-- ----------------------------
ALTER TABLE "public"."UserAnswer" ADD CONSTRAINT "UserAnswer_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table UserEmployee
-- ----------------------------
ALTER TABLE "public"."UserEmployee" ADD CONSTRAINT "UserEmployee_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table UserQuiz
-- ----------------------------
ALTER TABLE "public"."UserQuiz" ADD CONSTRAINT "UserQuiz_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table UserSecurity
-- ----------------------------
ALTER TABLE "public"."UserSecurity" ADD CONSTRAINT "UserSecurity_pkey" PRIMARY KEY ("UserId");

-- ----------------------------
-- Foreign Keys structure for table Answer
-- ----------------------------
ALTER TABLE "public"."Answer" ADD CONSTRAINT "Answer_QuestionId_fkey" FOREIGN KEY ("QuestionId") REFERENCES "public"."Question" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table AnswerTamplate
-- ----------------------------
ALTER TABLE "public"."AnswerTamplate" ADD CONSTRAINT "AnswerTamplate_QuestionTamplateId_fkey" FOREIGN KEY ("QuestionTamplateId") REFERENCES "public"."QuestionTemplate" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Question
-- ----------------------------
ALTER TABLE "public"."Question" ADD CONSTRAINT "Question_QuestionTypeId_fkey" FOREIGN KEY ("QuestionTypeId") REFERENCES "public"."QuestionType" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Question" ADD CONSTRAINT "Question_QuizId_fkey" FOREIGN KEY ("QuizId") REFERENCES "public"."Quiz" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table QuestionTemplate
-- ----------------------------
ALTER TABLE "public"."QuestionTemplate" ADD CONSTRAINT "QuestionTemplate_QuestionTypeId_fkey" FOREIGN KEY ("QuestionTypeId") REFERENCES "public"."QuestionType" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Quiz
-- ----------------------------
ALTER TABLE "public"."Quiz" ADD CONSTRAINT "Quiz_StatusId_fkey" FOREIGN KEY ("StatusId") REFERENCES "public"."Status" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Subscription
-- ----------------------------
ALTER TABLE "public"."Subscription" ADD CONSTRAINT "Subscription_TypeId_fkey" FOREIGN KEY ("TypeId") REFERENCES "public"."SubscriptionType" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Subscription" ADD CONSTRAINT "Subscription_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table SubscriptionType
-- ----------------------------
ALTER TABLE "public"."SubscriptionType" ADD CONSTRAINT "SubscriptionType_LongevityTypeId_fkey" FOREIGN KEY ("LongevityTypeId") REFERENCES "public"."LongevityType" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table User
-- ----------------------------
ALTER TABLE "public"."User" ADD CONSTRAINT "User_RoleId_fkey" FOREIGN KEY ("RoleId") REFERENCES "public"."Role" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table UserAnswer
-- ----------------------------
ALTER TABLE "public"."UserAnswer" ADD CONSTRAINT "UserAnswer_AnswerId_fkey" FOREIGN KEY ("AnswerId") REFERENCES "public"."Answer" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."UserAnswer" ADD CONSTRAINT "UserAnswer_EmployeeId_fkey" FOREIGN KEY ("EmployeeId") REFERENCES "public"."Employee" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."UserAnswer" ADD CONSTRAINT "UserAnswer_QuestionId_fkey" FOREIGN KEY ("QuestionId") REFERENCES "public"."Question" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."UserAnswer" ADD CONSTRAINT "UserAnswer_QuizId_fkey" FOREIGN KEY ("QuizId") REFERENCES "public"."Quiz" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table UserEmployee
-- ----------------------------
ALTER TABLE "public"."UserEmployee" ADD CONSTRAINT "UserEmployee_EmployeeId_fkey" FOREIGN KEY ("EmployeeId") REFERENCES "public"."Employee" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."UserEmployee" ADD CONSTRAINT "UserEmployee_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table UserQuiz
-- ----------------------------
ALTER TABLE "public"."UserQuiz" ADD CONSTRAINT "UserQuiz_EmployeeId_fkey" FOREIGN KEY ("EmployeeId") REFERENCES "public"."Employee" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."UserQuiz" ADD CONSTRAINT "UserQuiz_QuizId_fkey" FOREIGN KEY ("QuizId") REFERENCES "public"."Quiz" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."UserQuiz" ADD CONSTRAINT "UserQuiz_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table UserSecurity
-- ----------------------------
ALTER TABLE "public"."UserSecurity" ADD CONSTRAINT "UserSecurity_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
