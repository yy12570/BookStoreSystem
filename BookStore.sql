use BookStore
create table Users
(
UserId int identity primary key not null, -- 用户UID：由数据库生成
UserEMail varchar(25) not null, -- 用户信息：邮箱
UserName varchar(30) not null, -- 用户名
UserPassword varchar(18),  -- 用户密码
UserGender char(2),  -- 用户信息：性别
UserRegTime datetime not null, -- 用户信息：注册时间
UserStatus int not null, -- 用户状态，0正常 1封禁 2永封
UserBanUntil datetime, -- 用户解封时间
UserFlag int not null -- 用户等级，0普通用户 1VIP 99管理员
)


create table Books
(
BookId int identity primary key not null, -- 图书ID：由数据库生成
BookName varchar(100) not null, -- 书名：
BookContent varchar(100) not null,   --图书信息
BookAuthorId int not null, -- 图书作者ID
BookAddTime datetime not null, -- 图书上架时间
BookClassId int not null,  -- 图书类别ID
BookPrice money,  -- 图书价格
BookSales int not null, -- 图书销量
BookAllowance int not null, -- 图书库存
BookNo varchar(30) not null,--书号
)

create table Authors
(
AuthorId int identity primary key not null, -- 作者ID
AuthorName varchar(50) not null -- 作者姓名
)

create table BookClass
(
ClassId int identity primary key not null, -- 类别ID
ClassName varchar(50) not null -- 类名
)

create table Orders
(
OrderId int primary key identity not null, -- 订单号
OrderUserId int not null, -- 订单用户id
OrderBookId int not null, -- 订单图书id
OrderBookCount int not null, -- 购买数量
OrderPrice money not null, -- 订单成交价格
OrderCreateTime datetime not null, -- 订单创建时间
OrderStatus int not null -- 订单状态 0为未付款 1为已付款 2为已取消
)

create table Cart
(
UserId int not null, -- 用户id
BookId int not null, -- 图书id
BookCount int not null, -- 购买数量
-- Price int not null, -- 价格(外键) 
)

