# StudyCardApplication

A simple flashcard application made in WPF .Net 6.0 attempting to follow the MVVM pattern. You can create decks of flashcards and run through them to practice! The application was developed in a very short time and is lacking some visual polish, but it is fully functional.

Reflections:

  * The way I handled navigation in this one does not feel like an ideal solution. In an MVVM pattern a View Model should probably not need a reference to another View Model.
  
  * It feels unecessary to have to write unique ICommand classes for every event-style action you need to take. There's probably a better way.

![image](https://user-images.githubusercontent.com/131958687/234818654-61ca121e-c861-46dd-9e88-f7012a0cc06b.png)

![image](https://user-images.githubusercontent.com/131958687/234818740-cc94e48c-28e0-49f2-b20e-083786dbb8a3.png)

![image](https://user-images.githubusercontent.com/131958687/234818823-e8a53d4d-0d61-4c6a-890a-7c3fa9f1f7fe.png)

