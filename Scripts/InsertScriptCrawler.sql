select * from Status

insert into Status
select getdate(), null, null, 'Awaiting Processing'

insert into Status
select getdate(), null, null, 'Successfully Concluded'

insert into Status
select getdate(), null, null, 'In Execution'

insert into Status
select getdate(), null, null, 'Error'

insert into Status
select getdate(), null, null, 'Execution Error'

insert into Status
select getdate(), null, null, 'Error Execution Waiting Analysis'

select * from RobotType

insert into RobotType
select getdate(), null, null, 'Download Card'

insert into RobotType
select getdate(), null, null, 'Download Card Detail'

insert into RobotType
select getdate(), null, null, 'Download Deck'

insert into RobotType
select getdate(), null, null, 'Download Deck Detail'

select * from Site

insert into Site
select getdate(), null, null, 'SWDestinyDB', 'https://swdestinydb.com/'

select * from Robot

insert into Robot
select getdate(), null, null, 'Download Card SWDestinyDB', 1, 1

insert into Robot
select getdate(), null, null, 'Download Card Detail SWDestinyDB', 2, 1

insert into Robot
select getdate(), null, null, 'Download Deck SWDestinyDB', 3, 1

insert into Robot
select getdate(), null, null, 'Download Deck Detail SWDestinyDB', 4, 1