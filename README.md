# UUID Generator
A simple Windows desktop application for generating various types of UUIDs (GUIDs in Windows).
The primary use for this application is to generate timestamp-based sequential UUIDs to be stored in DBs as a primary index.

There is support for the following types of UUIDs.

* Comb/Time: Combination time-based UUIDs that are appropriate for most DBs (non-Microsoft) as a primary key because they are sequential due to the partial timestamp included.
* Comb/Time: Combination time-based UUIDs that are appropriate for Microsoft SQL Server as a primary key because they are sequential due to the partial timestamp included and store the timestamp portion at the right-most position. SQL Server treats its `uniqueidentifier` data type right-to-left with regard to most significance and ordering.
* Random: These are truly random UUIDs. These are not a good fit for RDMSes as a primary key, as they are non-sequential.
