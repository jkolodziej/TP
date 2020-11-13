# Technologie programowania Lab

## Team

| Name Surname (initials) | GUID                                     |
| ----------------------- | ---------------------------------------- |
| Julia Kołodziej         | {DF776A2C-BD49-4A07-B600-5DE51B870221}   |
| Karolina Kowalczyk      | {1B425776-5914-4D07-9322-8ABCA32EB669}   |

## Check List

- [ ] text is in C# and use .NET
- [ ] build succeeded
- [ ] all UT are green
- [ ] Object model representing process data
  - [ ] structured data is used to create object model
  - [ ] Users: a collection of all actors relevant to the implemented business process (e.g.: readers, customers, suppliers, etc)
  - [ ] Catalog: a dictionary of the goods descriptions (e.g.: books, good )
  - [ ] Process state: description of the current process state (e.g: the current content of the shop, library, etc.)
  - [ ] Events: description of **all** events contributing to the process state change in time (polymorphic approach)
- [ ] Dependency injection (additional framework is not required)
- [ ] `Data` layer is clearly stated using language terms only (no database of file access is required)
- [ ] `Data` API is abstract
- [ ] `Logic` layer is clearly stated using language terms only
- [ ] `Logic` API is clearly stated
- [ ] `Logic` uses only the abstract `Data` layer API
- [ ] Unit Test - 2+ testing data generation methods
- [ ] layers are tested independently
- [ ] only code in the solution is tested
