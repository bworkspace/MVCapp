USE [CaseStudy]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 6/8/2020 2:35:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Accountno] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Branchname] [varchar](100) NOT NULL,
	[IFSC] [varchar](20) NOT NULL,
	[Balance] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Accountno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddCustomer]    Script Date: 6/8/2020 2:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_AddCustomer]       
(      
    @Accountno int,    
    @Name varchar(100),     
    @Branchname VARCHAR(20),      
    @IFSC VARCHAR(20),      
    @Balance float
)      
As       
Begin       
    Insert into Customers (Accountno,Name,Branchname,IFSC,Balance)       
    Values (@Accountno,@Name,@Branchname,@IFSC, @Balance)       
End 
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteCustomer]    Script Date: 6/8/2020 2:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_DeleteCustomer]       
(        
   @Accountno int        
)        
As         
begin        
   Delete from Customers where Accountno=@Accountno        
End 
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllCustomers]    Script Date: 6/8/2020 2:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_GetAllCustomers]      
As      
Begin      
    select   
   Accountno,      
   Name,   
   Branchname,    
   IFSC,      
   Balance
    from Customers     
End  
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateCustomer]    Script Date: 6/8/2020 2:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_UpdateCustomer]        
(        
    @Accountno int,    
    @Name varchar(100),     
    @Branchname VARCHAR(20),      
    @IFSC VARCHAR(20),      
    @Balance float  
)        
As        
begin        
   Update Customers         
   set 
    Accountno = @Accountno,    
    Name = @Name,     
    Branchname = @Branchname,      
    IFSC = @IFSC,      
    Balance = @Balance 
  
   where Accountno=@Accountno      
End 
GO
