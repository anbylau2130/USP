
alter table SysCorp
add LogoUrl varchar(50) not null default('') --公司logo
alter table SysCorp
add LogoIcon varchar(50) not null default('') --公司Icon
alter table SysCorp
alter column Mobile varchar(32)
alter table SysCorp
alter column IdCard varchar(32)

alter table SysOperator
alter column Mobile varchar(32)
alter table SysOperator
alter column IdCard varchar(32)

