alter table student drop column studentgroup_id;
alter table student add column studentgroup_id integer references studentgroup(id);