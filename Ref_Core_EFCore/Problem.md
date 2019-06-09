# Keep REST API - Similar to Google Keep

#This is in continuation to your previous assignment

**Objective:** Create ASP.NET Core Web API which should be able to drive some of the features of Google Keep Application.

The intent of the application is to use **Entity Framework Core** and **ASP.NET Core Web API**

## Google Keep Specs
- A Note can have potential things:
  - Must have a **title**
  - Can have **plain text**
  - Can have **checklist**, basically a list of items
  - Can have a set of **labels**
  
- Should be able to **create** notes
- Should be able to **retrieve** all/individual notes
- Should be able to **delete** a Note
- Should be able to **Add/Remove/Edit** label for a note
- Should be able to **Add/Remove/Edit** checklist for a note
- Should be able to **Search** note/notes by label
- Should be able to **Search** note/notes by title

## You API should expose below mentioned URI

- GET  /notes - To retreive all notes
- GET /notes/{id} - to retreive a note by Id
- POST /notes - To create a new Note
- DELETE /notes/{id} - To delete an existing note

- POST /notes/{id}/labels - To add a new label for existing note
- DELETE /notes/{id}/labels/{labelid} - To delete a label from existing note
- PUT /notes/{id}/labels/{labelid} - To update an existing label of existing note

- POST /notes/{id}/checklist - To add a new checklist item for existing note
- DELETE /notes/{id}/checklist/{itemId} - To delete a checklist item from existing note
- PUT /notes/{id}/checklist/{itemId} - To update an existing checklist item of existing note

- GET  /notes/{lblText} - To retreive all notes by label
- GET  /notes/{title} - To retreive all notes by title

## Instructions
- Boilerplate for the assignment is located here:
  https://gitlab-cts.stackroute.in/aspnetcore/aspnetcore_assignment_step3_boilerplate.git

