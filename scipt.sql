/*==============================================================*/
/* DBMS name:      ORACLE Version 11g                           */
/* Created on:     3/31/2021 10:09:41 AM                        */
/*==============================================================*/


alter table CHAM_CONG
   drop constraint FK_CHAM_CON_NHAN_VIEN_NHAN_VIE;

alter table CT_DON_THUOC
   drop constraint FK_CT_DON_T_CT_DON_TH_THUOC;

alter table CT_HOA_DON
   drop constraint FK_CT_HOA_D_CT_HOA_DO_DICH_VU;

alter table CT_HOA_DON
   drop constraint FK_CT_HOA_D_CT_HOA_DO_HOA_DON;

alter table DICH_VU
   drop constraint FK_DICH_VU_THUC_HIEN_NHAN_VIE;

alter table DON_THUOC
   drop constraint FK_DON_THUO_THUOC_2_HO_SO_BE;

alter table HOA_DON
   drop constraint FK_HOA_DON_CO_HO_SO_BE;

alter table HO_SO_BENH_NHAN
   drop constraint FK_HO_SO_BE_DIEU_PHOI_NHAN_VIE;

alter table HO_SO_BENH_NHAN
   drop constraint FK_HO_SO_BE_DIEU_TRI_NHAN_VIE;

alter table HO_SO_BENH_NHAN
   drop constraint FK_HO_SO_BE_SO_HUU_BENH_NHA;

alter table HO_SO_DICH_VU
   drop constraint FK_HO_SO_DI_HO_SO_DIC_DICH_VU;

alter table HO_SO_DICH_VU
   drop constraint FK_HO_SO_DI_HO_SO_DIC_HO_SO_BE;

alter table NHAN_VIEN
   drop constraint FK_NHAN_VIE_THUOC_DON_VI;

drop table BENH_NHAN cascade constraints;

drop table CHAM_CONG cascade constraints;

drop table CT_DON_THUOC cascade constraints;

drop table CT_HOA_DON cascade constraints;

drop table DICH_VU cascade constraints;

drop table DON_THUOC cascade constraints;

drop table DON_VI cascade constraints;

drop table HOA_DON cascade constraints;

drop table HO_SO_BENH_NHAN cascade constraints;

drop table HO_SO_DICH_VU cascade constraints;

drop table NHAN_VIEN cascade constraints;

drop table THUOC cascade constraints;

/*==============================================================*/
/* Table: BENH_NHAN                                             */
/*==============================================================*/
create table BENH_NHAN 
(
   MA_BNHAN             VARCHAR2(10)         not null,
   HO_TEN               VARCHAR2(50),
   NGAY_SINH            DATE,
   DIA_CHI              VARCHAR2(50),
   SDT                  VARCHAR2(50),
   constraint PK_BENH_NHAN primary key (MA_BNHAN)
);

/*==============================================================*/
/* Table: CHAM_CONG                                             */
/*==============================================================*/
create table CHAM_CONG 
(
   MA_NV                VARCHAR2(10)         not null,
   THANG_NAM            DATE                 not null,
   SO_NGAY_CHAM_CONG    INTEGER
);

/*==============================================================*/
/* Table: CT_DON_THUOC                                          */
/*==============================================================*/
create table CT_DON_THUOC 
(
   MA_DON_THUOC         VARCHAR2(10)         not null,
   MA_THUOC             VARCHAR2(10)         not null,
   constraint PK_CT_DON_THUOC primary key (MA_DON_THUOC, MA_THUOC)
);

/*==============================================================*/
/* Table: CT_HOA_DON                                            */
/*==============================================================*/
create table CT_HOA_DON 
(
   MA_DVU               VARCHAR2(10)         not null,
   SO_HD                VARCHAR2(10)         not null,
   constraint PK_CT_HOA_DON primary key (MA_DVU, SO_HD)
);

/*==============================================================*/
/* Table: DICH_VU                                               */
/*==============================================================*/
create table DICH_VU 
(
   MA_DVU               VARCHAR2(10)         not null,
   MA_NV                VARCHAR2(10)         not null,
   TEN_DVU              VARCHAR2(50),
   DON_GIA              INTEGER,
   constraint PK_DICH_VU primary key (MA_DVU)
);

/*==============================================================*/
/* Table: DON_THUOC                                             */
/*==============================================================*/
create table DON_THUOC 
(
   MA_DON_THUOC         VARCHAR2(10)         not null,
   MA_KBENH             VARCHAR2(10)         not null,
   NVPT                 VARCHAR2(10),
   constraint PK_DON_THUOC primary key (MA_DON_THUOC)
);

/*==============================================================*/
/* Table: DON_VI                                                */
/*==============================================================*/
create table DON_VI 
(
   MA_DVI               VARCHAR2(10)         not null,
   TEN_DVI              VARCHAR2(50),
   constraint PK_DON_VI primary key (MA_DVI)
);

/*==============================================================*/
/* Table: HOA_DON                                               */
/*==============================================================*/
create table HOA_DON 
(
   SO_HD                VARCHAR2(10)         not null,
   MA_KBENH             VARCHAR2(10)         not null,
   NGAY_HD              DATE,
   NGUOI_PT             VARCHAR2(10),
   TONG_TIEN            INTEGER,
   constraint PK_HOA_DON primary key (SO_HD)
);

/*==============================================================*/
/* Table: HO_SO_BENH_NHAN                                       */
/*==============================================================*/
create table HO_SO_BENH_NHAN 
(
   MA_KBENH             VARCHAR2(10)         not null,
   MA_NV                VARCHAR2(10)         not null,
   MA_BNHAN             VARCHAR2(10)         not null,
   MA_BSI               VARCHAR2(10)         not null,
   NGAY_KBENH           DATE,
   TINH_TRANG_BAN_DAU   VARCHAR2(50),
   KET_LUAN_BS          VARCHAR2(50),
   constraint PK_HO_SO_BENH_NHAN primary key (MA_KBENH)
);

/*==============================================================*/
/* Table: HO_SO_DICH_VU                                         */
/*==============================================================*/
create table HO_SO_DICH_VU 
(
   MA_DVU               VARCHAR2(10)         not null,
   MA_KBENH             VARCHAR2(10)         not null,
   NGAY_GIO             DATE,
   NGUOI_THUC_HIEN      VARCHAR2(50),
   KET_LUAN             VARCHAR2(50),
   constraint PK_HO_SO_DICH_VU primary key (MA_DVU, MA_KBENH)
);

/*==============================================================*/
/* Table: NHAN_VIEN                                             */
/*==============================================================*/
create table NHAN_VIEN 
(
   MA_NV                VARCHAR2(10)         not null,
   MA_DVI               VARCHAR2(10)         not null,
   HO_TEN               VARCHAR2(50),
   DIA_CHI              VARCHAR2(50),
   SDT                  VARCHAR2(50),
   LUONG                INTEGER,
   PHU_CAP              INTEGER,
   VAI_TRO              VARCHAR2(10),
   constraint PK_NHAN_VIEN primary key (MA_NV)
);

/*==============================================================*/
/* Table: THUOC                                                 */
/*==============================================================*/
create table THUOC 
(
   MA_THUOC             VARCHAR2(10)         not null,
   TEN_THUOC            VARCHAR2(50),
   DVT                  VARCHAR2(10),
   DON_GIA              INTEGER,
   LUU_Y                CLOB,
   constraint PK_THUOC primary key (MA_THUOC)
);

alter table CHAM_CONG
   add constraint FK_CHAM_CON_NHAN_VIEN_NHAN_VIE foreign key (MA_NV)
      references NHAN_VIEN (MA_NV);

alter table CT_DON_THUOC
   add constraint FK_CT_DON_T_CT_DON_TH_THUOC foreign key (MA_THUOC)
      references THUOC (MA_THUOC);

alter table CT_HOA_DON
   add constraint FK_CT_HOA_D_CT_HOA_DO_DICH_VU foreign key (MA_DVU)
      references DICH_VU (MA_DVU);

alter table CT_HOA_DON
   add constraint FK_CT_HOA_D_CT_HOA_DO_HOA_DON foreign key (SO_HD)
      references HOA_DON (SO_HD);

alter table DICH_VU
   add constraint FK_DICH_VU_THUC_HIEN_NHAN_VIE foreign key (MA_NV)
      references NHAN_VIEN (MA_NV);

alter table DON_THUOC
   add constraint FK_DON_THUO_THUOC_2_HO_SO_BE foreign key (MA_KBENH)
      references HO_SO_BENH_NHAN (MA_KBENH);

alter table HOA_DON
   add constraint FK_HOA_DON_CO_HO_SO_BE foreign key (MA_KBENH)
      references HO_SO_BENH_NHAN (MA_KBENH);

alter table HO_SO_BENH_NHAN
   add constraint FK_HO_SO_BE_DIEU_PHOI_NHAN_VIE foreign key (MA_NV)
      references NHAN_VIEN (MA_NV);

alter table HO_SO_BENH_NHAN
   add constraint FK_HO_SO_BE_DIEU_TRI_NHAN_VIE foreign key (MA_BSI)
      references NHAN_VIEN (MA_NV);

alter table HO_SO_BENH_NHAN
   add constraint FK_HO_SO_BE_SO_HUU_BENH_NHA foreign key (MA_BNHAN)
      references BENH_NHAN (MA_BNHAN);

alter table HO_SO_DICH_VU
   add constraint FK_HO_SO_DI_HO_SO_DIC_DICH_VU foreign key (MA_DVU)
      references DICH_VU (MA_DVU);

alter table HO_SO_DICH_VU
   add constraint FK_HO_SO_DI_HO_SO_DIC_HO_SO_BE foreign key (MA_KBENH)
      references HO_SO_BENH_NHAN (MA_KBENH);

alter table NHAN_VIEN
   add constraint FK_NHAN_VIE_THUOC_DON_VI foreign key (MA_DVI)
      references DON_VI (MA_DVI);

