# Project Status
- 0 errors
- 1 bug 

**Bug:** While an incorrect password (with existing userName) kicks a user out, a non-existent userName let's them in regardless.
**Cause:** The way I built the menus and/or incomplete try/throw/catch blocks
**Solution(s):** 
- Move the displayEmployeeMenu and displayManagerMenu bits somewhere more appropriate
- Working on this helped me understand throw/Catch so use that insight to build them properly here and elsewhere

## Working Functionality
- Initial menu offers: Login, Register, Exit
    - **EmployeeMenu:** 
        - Can view their own tickets
        - Create new ticket

    - **ManagerMenu:** Choices:
        - Create a New Ticket - YES
        - View My Tickets - YES
        - View Ticket by TicketID - YES
        - View Tickets by UserName YES
        - View Tickets by Status - YES
        - View Entire User List = YES
        - View Entire Ticket  = YES
- Create User
- Login

## Major To Do
- WebAPI
- Controllers
- Endpoint mapping
- Http stuff

## Minor To Do
- ConnectionFactory

## Wish List
- Returned tickets show usernames
