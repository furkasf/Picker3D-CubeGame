# Picker3D-LevelUp
that project created for Level-UP assignment 

This project created for created for level-up asigment made in 7 day. I real enjoy to make that game that asigment allow
me to use libarys like dotween in deep and obeserver pattern challenge help me to understant how reel usefull that pattern
in pratics.


Save System

![Screenshot 2022-05-23 173428](https://user-images.githubusercontent.com/60402673/170464954-99e2aede-b0c6-4683-873c-8bf6bdb534e6.png)

I use to BinaryFormater Base save system to create save file to hard drive that save just store score data,  even though PlayerPrefabs base save system much more simple
to implament to that scale game but I thought to PlayerPrefab use to add setting to game and also file base save Sytem easly convert xml or json base save format just
in case some point you need to work with remote data base that would be extra helpfull.

Scriptable Objects And PrefabLoading

![Screenshot 2022-05-26 132415](https://user-images.githubusercontent.com/60402673/170469712-4d758cc6-2a4e-4d8d-81fa-0fc6c29aa098.png)

I design all level in prefab format that allow me to easly design new level and load level in runtime from scriptable object, each level actual consist big and
small number of item when they load in next level or restart reduce to draw call and memory allocation and deallocation , all big number og objects in store ball
pool,

URP settings

![Screenshot 2022-05-26 125045](https://user-images.githubusercontent.com/60402673/170466354-00000fff-7cfe-4ec4-80e4-e099f369f91f.png)

I use unity URP asset packet to convert my pipe line to URP, that packed allow to easly made setting on URP on it's scriptable
object without requiring write extra script for settings.

Object Pool And Event System

I use object Pool for gather all balls use in game very start on game, which reduce to memory allocation and deallocation
when load and start level from prefabs.

Event System or observer patttern use to outo and sync to trail System when Player thouch the trail area chain of event exacuted
and magic is happen.

DoTween

That libary use to change scale of player after trail and and animation of hellicopter. that actualy very usefull libary with poor
documantation.

CinaMachine

I use to Cinamation Preaty much as normal camera bigest advantage of cinamachine smooth blending doesnt use in that project
even orginal game dont use as  I see.

