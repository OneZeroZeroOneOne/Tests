/*
 Navicat Premium Data Transfer

 Source Server         : 104.248.250.163
 Source Server Type    : PostgreSQL
 Source Server Version : 120005
 Source Host           : 104.248.250.163:5432
 Source Catalog        : postgres
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 120005
 File Encoding         : 65001

 Date: 29/12/2020 04:51:02
*/


-- ----------------------------
-- Sequence structure for Adjective_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Adjective_Id_seq";
CREATE SEQUENCE "public"."Adjective_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for AnswerTemplate_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."AnswerTemplate_Id_seq";
CREATE SEQUENCE "public"."AnswerTemplate_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

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
-- Sequence structure for Avatar_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Avatar_id_seq";
CREATE SEQUENCE "public"."Avatar_id_seq" 
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
-- Sequence structure for NounCases_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."NounCases_Id_seq";
CREATE SEQUENCE "public"."NounCases_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for Noun_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Noun_Id_seq";
CREATE SEQUENCE "public"."Noun_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for PositionId_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."PositionId_seq";
CREATE SEQUENCE "public"."PositionId_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for QuestionTemplate_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."QuestionTemplate_Id_seq";
CREATE SEQUENCE "public"."QuestionTemplate_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
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
-- Sequence structure for Resume_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Resume_id_seq";
CREATE SEQUENCE "public"."Resume_id_seq" 
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
-- Sequence structure for Vacancy_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Vacancy_Id_seq";
CREATE SEQUENCE "public"."Vacancy_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for Verb_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Verb_Id_seq";
CREATE SEQUENCE "public"."Verb_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for positionid_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."positionid_seq";
CREATE SEQUENCE "public"."positionid_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Table structure for Adjective
-- ----------------------------
DROP TABLE IF EXISTS "public"."Adjective";
CREATE TABLE "public"."Adjective" (
  "Id" int4 NOT NULL DEFAULT nextval('"Adjective_Id_seq"'::regclass),
  "Json" json NOT NULL
)
;

-- ----------------------------
-- Table structure for Answer
-- ----------------------------
DROP TABLE IF EXISTS "public"."Answer";
CREATE TABLE "public"."Answer" (
  "Id" int4 NOT NULL DEFAULT nextval('"Answer_Id_seq"'::regclass),
  "QuestionId" int4 NOT NULL,
  "Text" text COLLATE "pg_catalog"."default" NOT NULL,
  "CreateDateTime" timestamp(6) NOT NULL,
  "IsRight" bool NOT NULL
)
;

-- ----------------------------
-- Table structure for AnswerTamplate
-- ----------------------------
DROP TABLE IF EXISTS "public"."AnswerTamplate";
CREATE TABLE "public"."AnswerTamplate" (
  "Id" int4 NOT NULL DEFAULT nextval('"AnswerTemplate_Id_seq"'::regclass),
  "QuestionTamplateId" int4 NOT NULL,
  "Text" text COLLATE "pg_catalog"."default" NOT NULL,
  "IsRight" bool NOT NULL
)
;

-- ----------------------------
-- Table structure for Avatar
-- ----------------------------
DROP TABLE IF EXISTS "public"."Avatar";
CREATE TABLE "public"."Avatar" (
  "Id" int4 NOT NULL DEFAULT nextval('"Avatar_id_seq"'::regclass),
  "Path" text COLLATE "pg_catalog"."default" NOT NULL,
  "Name" text COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Table structure for DiscountType
-- ----------------------------
DROP TABLE IF EXISTS "public"."DiscountType";
CREATE TABLE "public"."DiscountType" (
  "Id" int4 NOT NULL,
  "BreakpointLongevityValue" int4 NOT NULL,
  "BreakpointSubscriptionTypeId" int4 NOT NULL,
  "IsAccumulative" bool NOT NULL,
  "DiscountValue" numeric(255,0) NOT NULL
)
;

-- ----------------------------
-- Table structure for Employee
-- ----------------------------
DROP TABLE IF EXISTS "public"."Employee";
CREATE TABLE "public"."Employee" (
  "Id" int4 NOT NULL DEFAULT nextval('"Employee_Id_seq"'::regclass),
  "FirstName" text COLLATE "pg_catalog"."default" NOT NULL,
  "MiddleName" text COLLATE "pg_catalog"."default",
  "DateOfBirth" timestamp(6),
  "Email" text COLLATE "pg_catalog"."default",
  "SurName" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "Phone" text COLLATE "pg_catalog"."default",
  "Salary" int4,
  "SotialNetworks" text COLLATE "pg_catalog"."default",
  "Adress" text COLLATE "pg_catalog"."default",
  "IsCandidate" bool NOT NULL,
  "AvatarId" int4,
  "ResumeId" int4,
  "PositionId" int4 NOT NULL,
  "VacancyId" int4
)
;

-- ----------------------------
-- Table structure for FakeEmployee
-- ----------------------------
DROP TABLE IF EXISTS "public"."FakeEmployee";
CREATE TABLE "public"."FakeEmployee" (
  "Id" int4 NOT NULL
)
;

-- ----------------------------
-- Table structure for GlobalSetting
-- ----------------------------
DROP TABLE IF EXISTS "public"."GlobalSetting";
CREATE TABLE "public"."GlobalSetting" (
  "Id" int4 NOT NULL,
  "Key" text COLLATE "pg_catalog"."default" NOT NULL,
  "StringValue" text COLLATE "pg_catalog"."default",
  "IntValue" int8
)
;

-- ----------------------------
-- Table structure for JwtOption
-- ----------------------------
DROP TABLE IF EXISTS "public"."JwtOption";
CREATE TABLE "public"."JwtOption" (
  "Issuer" text COLLATE "pg_catalog"."default" NOT NULL,
  "Audience" text COLLATE "pg_catalog"."default" NOT NULL,
  "Key" text COLLATE "pg_catalog"."default" NOT NULL,
  "Lifetime" int4 NOT NULL
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
-- Table structure for Notification
-- ----------------------------
DROP TABLE IF EXISTS "public"."Notification";
CREATE TABLE "public"."Notification" (
  "UserId" int4 NOT NULL,
  "NotificationId" uuid NOT NULL,
  "NotificationContent" text COLLATE "pg_catalog"."default",
  "NotificationTypeId" int4,
  "NotificationTargetTypeId" int4,
  "IsSeen" bool,
  "CreatedDateTime" timestamp(6),
  "ModifiedDateTime" timestamp(6),
  "ArchivedDateTime" timestamp(6),
  "SeenDateTime" timestamp(6),
  "FromUserId" int4
)
;

-- ----------------------------
-- Table structure for NotificationTargetType
-- ----------------------------
DROP TABLE IF EXISTS "public"."NotificationTargetType";
CREATE TABLE "public"."NotificationTargetType" (
  "NotificationTargetTypeId" int4 NOT NULL,
  "Name" text COLLATE "pg_catalog"."default",
  "Description" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Table structure for NotificationType
-- ----------------------------
DROP TABLE IF EXISTS "public"."NotificationType";
CREATE TABLE "public"."NotificationType" (
  "NotificationTypeId" int4 NOT NULL,
  "Name" text COLLATE "pg_catalog"."default",
  "Description" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Table structure for Noun
-- ----------------------------
DROP TABLE IF EXISTS "public"."Noun";
CREATE TABLE "public"."Noun" (
  "Id" int4 NOT NULL DEFAULT nextval('"Noun_Id_seq"'::regclass),
  "Json" json NOT NULL,
  "Gender" text COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Table structure for Order
-- ----------------------------
DROP TABLE IF EXISTS "public"."Order";
CREATE TABLE "public"."Order" (
  "Id" uuid NOT NULL,
  "UserId" int4 NOT NULL,
  "StatusId" int4 NOT NULL,
  "CreatedDateTime" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP
)
;

-- ----------------------------
-- Table structure for OrderStatus
-- ----------------------------
DROP TABLE IF EXISTS "public"."OrderStatus";
CREATE TABLE "public"."OrderStatus" (
  "Id" int4 NOT NULL,
  "Name" text COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Table structure for OrderSubscription
-- ----------------------------
DROP TABLE IF EXISTS "public"."OrderSubscription";
CREATE TABLE "public"."OrderSubscription" (
  "SubscriptionId" int4 NOT NULL,
  "CreatedDateTime" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "OrderId" uuid NOT NULL
)
;

-- ----------------------------
-- Table structure for Position
-- ----------------------------
DROP TABLE IF EXISTS "public"."Position";
CREATE TABLE "public"."Position" (
  "Id" int4 NOT NULL DEFAULT nextval('positionid_seq'::regclass),
  "Title" text COLLATE "pg_catalog"."default" NOT NULL,
  "UserId" int4 NOT NULL,
  "Description" text COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Table structure for Question
-- ----------------------------
DROP TABLE IF EXISTS "public"."Question";
CREATE TABLE "public"."Question" (
  "Id" int4 NOT NULL DEFAULT nextval('"Question_Id_seq"'::regclass),
  "QuizId" int4 NOT NULL,
  "QuestionTypeId" int4 NOT NULL,
  "Text" text COLLATE "pg_catalog"."default" NOT NULL,
  "CreateDateTime" timestamp(6) NOT NULL
)
;

-- ----------------------------
-- Table structure for QuestionTemplate
-- ----------------------------
DROP TABLE IF EXISTS "public"."QuestionTemplate";
CREATE TABLE "public"."QuestionTemplate" (
  "Id" int4 NOT NULL DEFAULT nextval('"QuestionTemplate_Id_seq"'::regclass),
  "Text" text COLLATE "pg_catalog"."default" NOT NULL,
  "QuestionTypeId" int4 NOT NULL
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
  "CreateDateTime" timestamp(6) NOT NULL,
  "StatusId" int4 NOT NULL,
  "AddressKey" text COLLATE "pg_catalog"."default" NOT NULL,
  "UserId" int4 NOT NULL,
  "EmployeeId" int4 NOT NULL
)
;

-- ----------------------------
-- Table structure for Resume
-- ----------------------------
DROP TABLE IF EXISTS "public"."Resume";
CREATE TABLE "public"."Resume" (
  "Id" int4 NOT NULL DEFAULT nextval('"Resume_id_seq"'::regclass),
  "Path" text COLLATE "pg_catalog"."default" NOT NULL,
  "Name" text COLLATE "pg_catalog"."default" NOT NULL
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
  "CreatedDateTime" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP
)
;

-- ----------------------------
-- Table structure for SubscriptionDiscount
-- ----------------------------
DROP TABLE IF EXISTS "public"."SubscriptionDiscount";
CREATE TABLE "public"."SubscriptionDiscount" (
  "SubscriptionId" int4 NOT NULL,
  "DiscountTypeId" int4 NOT NULL,
  "TotalDiscount" numeric(255,0) NOT NULL,
  "CreatedDateTime" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP
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
  "AvailableTestAmount" int4 NOT NULL DEFAULT 1,
  "NeedToShow" bool NOT NULL
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
  "AvatarId" int4
)
;

-- ----------------------------
-- Table structure for UserAnswer
-- ----------------------------
DROP TABLE IF EXISTS "public"."UserAnswer";
CREATE TABLE "public"."UserAnswer" (
  "EmployeeId" int4 NOT NULL,
  "QuizId" int4 NOT NULL,
  "QuestionId" int4 NOT NULL,
  "AnswerId" int4 NOT NULL,
  "CreateDateTime" timestamp(6) NOT NULL
)
;

-- ----------------------------
-- Table structure for UserEmployee
-- ----------------------------
DROP TABLE IF EXISTS "public"."UserEmployee";
CREATE TABLE "public"."UserEmployee" (
  "Id" int4 NOT NULL DEFAULT nextval('"UserEmployee_Id_seq"'::regclass),
  "UserId" int4 NOT NULL,
  "EmployeeId" int4 NOT NULL
)
;

-- ----------------------------
-- Table structure for UserNotificationSetting
-- ----------------------------
DROP TABLE IF EXISTS "public"."UserNotificationSetting";
CREATE TABLE "public"."UserNotificationSetting" (
  "UserId" int4 NOT NULL,
  "NotificationTargetTypeId" int4 NOT NULL,
  "NotificationTypeId" int4 NOT NULL,
  "IsEnabled" bool NOT NULL
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
-- Table structure for Vacancy
-- ----------------------------
DROP TABLE IF EXISTS "public"."Vacancy";
CREATE TABLE "public"."Vacancy" (
  "Id" int4 NOT NULL DEFAULT nextval('"Vacancy_Id_seq"'::regclass),
  "Title" text COLLATE "pg_catalog"."default" NOT NULL,
  "UserId" int4 NOT NULL,
  "Description" text COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Table structure for Verb
-- ----------------------------
DROP TABLE IF EXISTS "public"."Verb";
CREATE TABLE "public"."Verb" (
  "Id" int4 NOT NULL DEFAULT nextval('"Verb_Id_seq"'::regclass),
  "Json" json NOT NULL
)
;

-- ----------------------------
-- Function structure for uuid_generate_v1
-- ----------------------------
DROP FUNCTION IF EXISTS "public"."uuid_generate_v1"();
CREATE OR REPLACE FUNCTION "public"."uuid_generate_v1"()
  RETURNS "pg_catalog"."uuid" AS '$libdir/uuid-ossp', 'uuid_generate_v1'
  LANGUAGE c VOLATILE STRICT
  COST 1;

-- ----------------------------
-- Function structure for uuid_generate_v1mc
-- ----------------------------
DROP FUNCTION IF EXISTS "public"."uuid_generate_v1mc"();
CREATE OR REPLACE FUNCTION "public"."uuid_generate_v1mc"()
  RETURNS "pg_catalog"."uuid" AS '$libdir/uuid-ossp', 'uuid_generate_v1mc'
  LANGUAGE c VOLATILE STRICT
  COST 1;

-- ----------------------------
-- Function structure for uuid_generate_v3
-- ----------------------------
DROP FUNCTION IF EXISTS "public"."uuid_generate_v3"("namespace" uuid, "name" text);
CREATE OR REPLACE FUNCTION "public"."uuid_generate_v3"("namespace" uuid, "name" text)
  RETURNS "pg_catalog"."uuid" AS '$libdir/uuid-ossp', 'uuid_generate_v3'
  LANGUAGE c IMMUTABLE STRICT
  COST 1;

-- ----------------------------
-- Function structure for uuid_generate_v4
-- ----------------------------
DROP FUNCTION IF EXISTS "public"."uuid_generate_v4"();
CREATE OR REPLACE FUNCTION "public"."uuid_generate_v4"()
  RETURNS "pg_catalog"."uuid" AS '$libdir/uuid-ossp', 'uuid_generate_v4'
  LANGUAGE c VOLATILE STRICT
  COST 1;

-- ----------------------------
-- Function structure for uuid_generate_v5
-- ----------------------------
DROP FUNCTION IF EXISTS "public"."uuid_generate_v5"("namespace" uuid, "name" text);
CREATE OR REPLACE FUNCTION "public"."uuid_generate_v5"("namespace" uuid, "name" text)
  RETURNS "pg_catalog"."uuid" AS '$libdir/uuid-ossp', 'uuid_generate_v5'
  LANGUAGE c IMMUTABLE STRICT
  COST 1;

-- ----------------------------
-- Function structure for uuid_nil
-- ----------------------------
DROP FUNCTION IF EXISTS "public"."uuid_nil"();
CREATE OR REPLACE FUNCTION "public"."uuid_nil"()
  RETURNS "pg_catalog"."uuid" AS '$libdir/uuid-ossp', 'uuid_nil'
  LANGUAGE c IMMUTABLE STRICT
  COST 1;

-- ----------------------------
-- Function structure for uuid_ns_dns
-- ----------------------------
DROP FUNCTION IF EXISTS "public"."uuid_ns_dns"();
CREATE OR REPLACE FUNCTION "public"."uuid_ns_dns"()
  RETURNS "pg_catalog"."uuid" AS '$libdir/uuid-ossp', 'uuid_ns_dns'
  LANGUAGE c IMMUTABLE STRICT
  COST 1;

-- ----------------------------
-- Function structure for uuid_ns_oid
-- ----------------------------
DROP FUNCTION IF EXISTS "public"."uuid_ns_oid"();
CREATE OR REPLACE FUNCTION "public"."uuid_ns_oid"()
  RETURNS "pg_catalog"."uuid" AS '$libdir/uuid-ossp', 'uuid_ns_oid'
  LANGUAGE c IMMUTABLE STRICT
  COST 1;

-- ----------------------------
-- Function structure for uuid_ns_url
-- ----------------------------
DROP FUNCTION IF EXISTS "public"."uuid_ns_url"();
CREATE OR REPLACE FUNCTION "public"."uuid_ns_url"()
  RETURNS "pg_catalog"."uuid" AS '$libdir/uuid-ossp', 'uuid_ns_url'
  LANGUAGE c IMMUTABLE STRICT
  COST 1;

-- ----------------------------
-- Function structure for uuid_ns_x500
-- ----------------------------
DROP FUNCTION IF EXISTS "public"."uuid_ns_x500"();
CREATE OR REPLACE FUNCTION "public"."uuid_ns_x500"()
  RETURNS "pg_catalog"."uuid" AS '$libdir/uuid-ossp', 'uuid_ns_x500'
  LANGUAGE c IMMUTABLE STRICT
  COST 1;

-- ----------------------------
-- View structure for View_GetPositionsWithCount
-- ----------------------------
DROP VIEW IF EXISTS "public"."View_GetPositionsWithCount";
CREATE VIEW "public"."View_GetPositionsWithCount" AS  SELECT p."Id",
    p."Title",
    p."Description",
    t.count AS "Count",
    t."IsCandidate",
    p."UserId"
   FROM "Position" p
     JOIN LATERAL ( SELECT count(ee."Id") AS count,
            ee."IsCandidate"
           FROM "Employee" ee
          WHERE ee."PositionId" = p."Id"
          GROUP BY ee."IsCandidate") t ON true;

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."Adjective_Id_seq"', 4, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."AnswerTemplate_Id_seq"', 14, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Answer_Id_seq"
OWNED BY "public"."Answer"."Id";
SELECT setval('"public"."Answer_Id_seq"', 82, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Avatar_id_seq"
OWNED BY "public"."Avatar"."Id";
SELECT setval('"public"."Avatar_id_seq"', 44, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Employee_Id_seq"
OWNED BY "public"."Employee"."Id";
SELECT setval('"public"."Employee_Id_seq"', 87, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."LongevityType_Id_seq"
OWNED BY "public"."LongevityType"."Id";
SELECT setval('"public"."LongevityType_Id_seq"', 3, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."NounCases_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."Noun_Id_seq"', 3, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."PositionId_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."QuestionTemplate_Id_seq"', 3, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."QuestionType_Id_seq"
OWNED BY "public"."QuestionType"."Id";
SELECT setval('"public"."QuestionType_Id_seq"', 2, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Question_Id_seq"
OWNED BY "public"."Question"."Id";
SELECT setval('"public"."Question_Id_seq"', 30, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Quiz_Id_seq"
OWNED BY "public"."Quiz"."Id";
SELECT setval('"public"."Quiz_Id_seq"', 85, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Resume_id_seq"
OWNED BY "public"."Resume"."Id";
SELECT setval('"public"."Resume_id_seq"', 10, true);

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
SELECT setval('"public"."Status_Id_seq"', 4, true);

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
SELECT setval('"public"."Subscription_Id_seq"', 14, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."UserEmployee_Id_seq"
OWNED BY "public"."UserEmployee"."Id";
SELECT setval('"public"."UserEmployee_Id_seq"', 73, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."User_Id_seq"
OWNED BY "public"."User"."Id";
SELECT setval('"public"."User_Id_seq"', 47, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Vacancy_Id_seq"
OWNED BY "public"."Vacancy"."Id";
SELECT setval('"public"."Vacancy_Id_seq"', 2, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."Verb_Id_seq"', 3, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."positionid_seq"', 6, true);

-- ----------------------------
-- Primary Key structure for table Adjective
-- ----------------------------
ALTER TABLE "public"."Adjective" ADD CONSTRAINT "Adjective_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table Answer
-- ----------------------------
ALTER TABLE "public"."Answer" ADD CONSTRAINT "Answer_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table AnswerTamplate
-- ----------------------------
ALTER TABLE "public"."AnswerTamplate" ADD CONSTRAINT "AnswerTamplate_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table Avatar
-- ----------------------------
ALTER TABLE "public"."Avatar" ADD CONSTRAINT "Avatar_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Uniques structure for table DiscountType
-- ----------------------------
ALTER TABLE "public"."DiscountType" ADD CONSTRAINT "DiscountType_Id_BreakpointSubscriptionTypeId_key" UNIQUE ("Id");

-- ----------------------------
-- Primary Key structure for table DiscountType
-- ----------------------------
ALTER TABLE "public"."DiscountType" ADD CONSTRAINT "DiscountType_pkey" PRIMARY KEY ("Id", "BreakpointSubscriptionTypeId");

-- ----------------------------
-- Primary Key structure for table Employee
-- ----------------------------
ALTER TABLE "public"."Employee" ADD CONSTRAINT "Employee_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table FakeEmployee
-- ----------------------------
ALTER TABLE "public"."FakeEmployee" ADD CONSTRAINT "FakeEmployee_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table GlobalSetting
-- ----------------------------
ALTER TABLE "public"."GlobalSetting" ADD CONSTRAINT "GlobalSetting_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table LongevityType
-- ----------------------------
ALTER TABLE "public"."LongevityType" ADD CONSTRAINT "LongevityType_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table Notification
-- ----------------------------
ALTER TABLE "public"."Notification" ADD CONSTRAINT "Notification_pkey" PRIMARY KEY ("UserId", "NotificationId");

-- ----------------------------
-- Primary Key structure for table NotificationTargetType
-- ----------------------------
ALTER TABLE "public"."NotificationTargetType" ADD CONSTRAINT "NotificationTargetType_pkey" PRIMARY KEY ("NotificationTargetTypeId");

-- ----------------------------
-- Primary Key structure for table NotificationType
-- ----------------------------
ALTER TABLE "public"."NotificationType" ADD CONSTRAINT "NotificationType_pkey" PRIMARY KEY ("NotificationTypeId");

-- ----------------------------
-- Primary Key structure for table Noun
-- ----------------------------
ALTER TABLE "public"."Noun" ADD CONSTRAINT "Noun_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Uniques structure for table Order
-- ----------------------------
ALTER TABLE "public"."Order" ADD CONSTRAINT "Order_Id_key" UNIQUE ("Id");

-- ----------------------------
-- Primary Key structure for table Order
-- ----------------------------
ALTER TABLE "public"."Order" ADD CONSTRAINT "Order_pkey" PRIMARY KEY ("Id", "UserId");

-- ----------------------------
-- Primary Key structure for table OrderStatus
-- ----------------------------
ALTER TABLE "public"."OrderStatus" ADD CONSTRAINT "OrderStatus_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table OrderSubscription
-- ----------------------------
ALTER TABLE "public"."OrderSubscription" ADD CONSTRAINT "OrderSubscription_pkey" PRIMARY KEY ("SubscriptionId", "OrderId");

-- ----------------------------
-- Primary Key structure for table Position
-- ----------------------------
ALTER TABLE "public"."Position" ADD CONSTRAINT "Position_pkey" PRIMARY KEY ("Id");

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
-- Primary Key structure for table Resume
-- ----------------------------
ALTER TABLE "public"."Resume" ADD CONSTRAINT "Resume_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table Role
-- ----------------------------
ALTER TABLE "public"."Role" ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table Status
-- ----------------------------
ALTER TABLE "public"."Status" ADD CONSTRAINT "Status_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Uniques structure for table Subscription
-- ----------------------------
ALTER TABLE "public"."Subscription" ADD CONSTRAINT "Subscription_Id_key" UNIQUE ("Id");

-- ----------------------------
-- Primary Key structure for table Subscription
-- ----------------------------
ALTER TABLE "public"."Subscription" ADD CONSTRAINT "Subscription_pkey" PRIMARY KEY ("UserId", "Id");

-- ----------------------------
-- Primary Key structure for table SubscriptionDiscount
-- ----------------------------
ALTER TABLE "public"."SubscriptionDiscount" ADD CONSTRAINT "SubscriptionDiscount_pkey" PRIMARY KEY ("SubscriptionId", "DiscountTypeId");

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
ALTER TABLE "public"."UserAnswer" ADD CONSTRAINT "UserAnswer_pkey" PRIMARY KEY ("QuestionId");

-- ----------------------------
-- Primary Key structure for table UserEmployee
-- ----------------------------
ALTER TABLE "public"."UserEmployee" ADD CONSTRAINT "UserEmployee_pkey" PRIMARY KEY ("UserId", "EmployeeId");

-- ----------------------------
-- Primary Key structure for table UserNotificationSetting
-- ----------------------------
ALTER TABLE "public"."UserNotificationSetting" ADD CONSTRAINT "UserNotificationSetting_pkey" PRIMARY KEY ("UserId", "NotificationTargetTypeId", "NotificationTypeId");

-- ----------------------------
-- Primary Key structure for table UserSecurity
-- ----------------------------
ALTER TABLE "public"."UserSecurity" ADD CONSTRAINT "UserSecurity_pkey" PRIMARY KEY ("UserId");

-- ----------------------------
-- Primary Key structure for table Vacancy
-- ----------------------------
ALTER TABLE "public"."Vacancy" ADD CONSTRAINT "Vacancy_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table Verb
-- ----------------------------
ALTER TABLE "public"."Verb" ADD CONSTRAINT "Verb_pkey" PRIMARY KEY ("Id");

-- ----------------------------
-- Foreign Keys structure for table Answer
-- ----------------------------
ALTER TABLE "public"."Answer" ADD CONSTRAINT "Answer_QuestionId_fkey" FOREIGN KEY ("QuestionId") REFERENCES "public"."Question" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table AnswerTamplate
-- ----------------------------
ALTER TABLE "public"."AnswerTamplate" ADD CONSTRAINT "AnswerTamplate_QuestionTamplateId_fkey" FOREIGN KEY ("QuestionTamplateId") REFERENCES "public"."QuestionTemplate" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table DiscountType
-- ----------------------------
ALTER TABLE "public"."DiscountType" ADD CONSTRAINT "DiscountType_BreakpointSubscriptionTypeId_fkey" FOREIGN KEY ("BreakpointSubscriptionTypeId") REFERENCES "public"."SubscriptionType" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Employee
-- ----------------------------
ALTER TABLE "public"."Employee" ADD CONSTRAINT "Employee_AvatarId_fkey" FOREIGN KEY ("AvatarId") REFERENCES "public"."Avatar" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Employee" ADD CONSTRAINT "Employee_PositionId_fkey" FOREIGN KEY ("PositionId") REFERENCES "public"."Position" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Employee" ADD CONSTRAINT "Employee_ResumeId_fkey" FOREIGN KEY ("ResumeId") REFERENCES "public"."Resume" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Employee" ADD CONSTRAINT "Employee_VacancyId_fkey" FOREIGN KEY ("VacancyId") REFERENCES "public"."Vacancy" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table FakeEmployee
-- ----------------------------
ALTER TABLE "public"."FakeEmployee" ADD CONSTRAINT "FakeEmployee_Id_fkey" FOREIGN KEY ("Id") REFERENCES "public"."Employee" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Notification
-- ----------------------------
ALTER TABLE "public"."Notification" ADD CONSTRAINT "Notification_NotificationTargetTypeId_fkey" FOREIGN KEY ("NotificationTargetTypeId") REFERENCES "public"."NotificationTargetType" ("NotificationTargetTypeId") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Notification" ADD CONSTRAINT "Notification_NotificationTypeId_fkey" FOREIGN KEY ("NotificationTypeId") REFERENCES "public"."NotificationType" ("NotificationTypeId") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Notification" ADD CONSTRAINT "Notification_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Order
-- ----------------------------
ALTER TABLE "public"."Order" ADD CONSTRAINT "Order_StatusId_fkey" FOREIGN KEY ("StatusId") REFERENCES "public"."OrderStatus" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Order" ADD CONSTRAINT "Order_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table OrderSubscription
-- ----------------------------
ALTER TABLE "public"."OrderSubscription" ADD CONSTRAINT "OrderSubscription_OrderId_fkey" FOREIGN KEY ("OrderId") REFERENCES "public"."Order" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."OrderSubscription" ADD CONSTRAINT "OrderSubscription_SubscriptionId_fkey" FOREIGN KEY ("SubscriptionId") REFERENCES "public"."Subscription" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Position
-- ----------------------------
ALTER TABLE "public"."Position" ADD CONSTRAINT "Position_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

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
ALTER TABLE "public"."Quiz" ADD CONSTRAINT "Quiz_EmployeeId_fkey" FOREIGN KEY ("EmployeeId") REFERENCES "public"."Employee" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Quiz" ADD CONSTRAINT "Quiz_StatusId_fkey" FOREIGN KEY ("StatusId") REFERENCES "public"."Status" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Quiz" ADD CONSTRAINT "Quiz_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Subscription
-- ----------------------------
ALTER TABLE "public"."Subscription" ADD CONSTRAINT "Subscription_TypeId_fkey" FOREIGN KEY ("TypeId") REFERENCES "public"."SubscriptionType" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Subscription" ADD CONSTRAINT "Subscription_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table SubscriptionDiscount
-- ----------------------------
ALTER TABLE "public"."SubscriptionDiscount" ADD CONSTRAINT "SubscriptionDiscount_DiscountTypeId_fkey" FOREIGN KEY ("DiscountTypeId") REFERENCES "public"."DiscountType" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."SubscriptionDiscount" ADD CONSTRAINT "SubscriptionDiscount_SubscriptionId_fkey" FOREIGN KEY ("SubscriptionId") REFERENCES "public"."Subscription" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table SubscriptionType
-- ----------------------------
ALTER TABLE "public"."SubscriptionType" ADD CONSTRAINT "SubscriptionType_LongevityTypeId_fkey" FOREIGN KEY ("LongevityTypeId") REFERENCES "public"."LongevityType" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table User
-- ----------------------------
ALTER TABLE "public"."User" ADD CONSTRAINT "User_AvatarId_fkey" FOREIGN KEY ("AvatarId") REFERENCES "public"."Avatar" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
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
-- Foreign Keys structure for table UserNotificationSetting
-- ----------------------------
ALTER TABLE "public"."UserNotificationSetting" ADD CONSTRAINT "UserNotificationSetting_NotificationTargetTypeId_fkey" FOREIGN KEY ("NotificationTargetTypeId") REFERENCES "public"."NotificationTargetType" ("NotificationTargetTypeId") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."UserNotificationSetting" ADD CONSTRAINT "UserNotificationSetting_NotificationTypeId_fkey" FOREIGN KEY ("NotificationTypeId") REFERENCES "public"."NotificationType" ("NotificationTypeId") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."UserNotificationSetting" ADD CONSTRAINT "UserNotificationSetting_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table UserSecurity
-- ----------------------------
ALTER TABLE "public"."UserSecurity" ADD CONSTRAINT "UserSecurity_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Vacancy
-- ----------------------------
ALTER TABLE "public"."Vacancy" ADD CONSTRAINT "Vacancy_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
