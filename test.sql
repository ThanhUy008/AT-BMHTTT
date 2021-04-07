/*==============================================================*/
/* DBMS name:      ORACLE Version 11g                           */
/* Created on:     4/7/2021 1:30:13 PM                          */
/*==============================================================*/


alter table DIEM_SO
   drop constraint FK_DIEM_SO_DIEM_SO_MON_HOC;

alter table DIEM_SO
   drop constraint FK_DIEM_SO_DIEM_SO2_HOC_SINH;

alter table GIAO_VIEN
   drop constraint FK_GIAO_VIE_DAY_HOC_MON_HOC;

alter table HOC_SINH
   drop constraint FK_HOC_SINH_THUOC_VE_LOP_HOC;

drop index DIEM_SO2_FK;

drop index DIEM_SO_FK;

drop table DIEM_SO cascade constraints;

drop index DAY_HOC_FK;

drop table GIAO_VIEN cascade constraints;

drop index THUOC_VE_FK;

drop table HOC_SINH cascade constraints;

drop table LOP_HOC cascade constraints;

drop table MON_HOC cascade constraints;

/*==============================================================*/
/* Table: DIEM_SO                                               */
/*==============================================================*/
create table DIEM_SO 
(
   MA_MON               VARCHAR2(10)         not null,
   MA_SV                VARCHAR2(10)         not null,
   constraint PK_DIEM_SO primary key (MA_MON, MA_SV)
);

/*==============================================================*/
/* Index: DIEM_SO_FK                                            */
/*==============================================================*/
create index DIEM_SO_FK on DIEM_SO (
   MA_MON ASC
);

/*==============================================================*/
/* Index: DIEM_SO2_FK                                           */
/*==============================================================*/
create index DIEM_SO2_FK on DIEM_SO (
   MA_SV ASC
);

/*==============================================================*/
/* Table: GIAO_VIEN                                             */
/*==============================================================*/
create table GIAO_VIEN 
(
   MA_GV                VARCHAR2(10)         not null,
   MA_MON               VARCHAR2(10)         not null,
   TEN_GV               VARCHAR2(50),
   NGAY_SINH            DATE,
   LUONG                INTEGER,
   constraint PK_GIAO_VIEN primary key (MA_GV)
);

/*==============================================================*/
/* Index: DAY_HOC_FK                                            */
/*==============================================================*/
create index DAY_HOC_FK on GIAO_VIEN (
   MA_MON ASC
);

/*==============================================================*/
/* Table: HOC_SINH                                              */
/*==============================================================*/
create table HOC_SINH 
(
   MA_SV                VARCHAR2(10)         not null,
   MA_LOP               VARCHAR2(10)         not null,
   TEN_SV               VARCHAR2(50),
   NGAY_SINH            DATE,
   GIOI_TINH            VARCHAR2(10),
   constraint PK_HOC_SINH primary key (MA_SV)
);

/*==============================================================*/
/* Index: THUOC_VE_FK                                           */
/*==============================================================*/
create index THUOC_VE_FK on HOC_SINH (
   MA_LOP ASC
);

/*==============================================================*/
/* Table: LOP_HOC                                               */
/*==============================================================*/
create table LOP_HOC 
(
   MA_LOP               VARCHAR2(10)         not null,
   TEN_LOP              VARCHAR2(50),
   constraint PK_LOP_HOC primary key (MA_LOP)
);

/*==============================================================*/
/* Table: MON_HOC                                               */
/*==============================================================*/
create table MON_HOC 
(
   MA_MON               VARCHAR2(10)         not null,
   TEN_MON              VARCHAR2(50),
   constraint PK_MON_HOC primary key (MA_MON)
);

alter table DIEM_SO
   add constraint FK_DIEM_SO_DIEM_SO_MON_HOC foreign key (MA_MON)
      references MON_HOC (MA_MON);

alter table DIEM_SO
   add constraint FK_DIEM_SO_DIEM_SO2_HOC_SINH foreign key (MA_SV)
      references HOC_SINH (MA_SV);

alter table GIAO_VIEN
   add constraint FK_GIAO_VIE_DAY_HOC_MON_HOC foreign key (MA_MON)
      references MON_HOC (MA_MON);

alter table HOC_SINH
   add constraint FK_HOC_SINH_THUOC_VE_LOP_HOC foreign key (MA_LOP)
      references LOP_HOC (MA_LOP);

