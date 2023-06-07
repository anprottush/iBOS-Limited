/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [employeeId]
      ,[attendanceDate]
      ,[isPresent]
      ,[isAbsent]
      ,[isOffday]
  FROM [EmployeeCRUD].[dbo].[EmployeeAttendance]