# 6002CEM-Mobile-App

### This is an upload of a university project that was committed to a private university repository.

## Tabletop Companion

### Introduction

My app is a companion that's intended to be used by players of tabletop role-playing games.  The aim of the app is to provide a way for players to manage the various aspects of their characters in a neat and organised space.

### Background and Motivation

I decided to make this app since it can be challenging to keep track of everything and often leads to certain things being neglected, this app should allow for an easy and convenient way for players to keep track of anything that they might need for a good tabletop experience.  It is important that the service allows for the user to save their information and seperate it by each of their characters.  The user will be required to be signed in for app functionality as everything is saved on Supabase with their account IDs.

### Features

- User can create an account, sign in and sign out using Supabase authentication.
- The app remembers the currently logged in account.
- The user can create, delete and swap between characters.
- The app will always make sure the user is both signed in and has a character selected.
- The user can edit their character sheet, which is correctly loaded and saved based on their current character.
- The app has an in app dice roller, which also displays the total amount rolled.
- The user can manage their inventory, able to add and delete entries and have it saved based on character, displayed with a collection view.
- All information and saved data is saved on the Supabase cloud service.
