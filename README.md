# MED2-sensor-to-csv

Contains two Unity project:
- one that uses the old input system, which runs using Unity Remote 5 and creates a CSV file to the Unity Asset folder.
- and another, which uses that the new input system and works only by making a build to the phone and then it creates a CSV on the phone.

My implementation of the exercise works by pressing the button, which starts writing gyroscope attitude (x,y,z) data to a csv file. When you press the button again, it stops writing to the file.
