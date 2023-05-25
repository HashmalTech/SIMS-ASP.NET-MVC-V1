go
create view TBL_view_manegerole as
select um.username, m.menuid , m.parentid,m.menuname,m.menulink from TBL_menu m inner join TBL_usermenu um on m.menuid = um.menuId where um.status = '1'

select * from TBL_account