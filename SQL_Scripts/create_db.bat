ECHO off

sqlcmd -S localhost -E -i assistability_db.sql
sqlcmd -S localhost -E -i useraccount.sql
sqlcmd -S localhost -E -i role.sql
sqlcmd -S localhost -E -i usergroup.sql
sqlcmd -S localhost -E -i membership.sql
sqlcmd -S localhost -E -i membershiprole.sql
sqlcmd -S localhost -E -i routines.sql
sqlcmd -S localhost -E -i routinestep.sql
sqlcmd -S localhost -E -i routinestepcompletion.sql
sqlcmd -S localhost -E -i test.sql
sqlcmd -S localhost -E -i journal.sql
sqlcmd -S localhost -E -i journalEntry.sql
sqlcmd -S localhost -E -i usergroup-testdata.sql
sqlcmd -S localhost -E -i membership-testdata.sql
sqlcmd -S localhost -E -i membershiprole-testdata.sql

ECHO .
ECHO if no errors appear DB was created
PAUSE