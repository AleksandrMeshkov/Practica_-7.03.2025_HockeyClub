   M S B A M L   `   `   `  ����H  DAppHockeyClub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:AppHockeyClub.crud.coachesAppHockeyClub.crud.coaches  5   	   &     AppHockeyClub.crud.coaches.EditC   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:AppHockeyClub.crud.coaches     5   	     � Title$/  )Редактировать тренера��5   	   $	��400��5	   	   $	��400��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $1��+Редактирование тренера��6   $��0��5      $��16(�5      $
��Bold"�5      $��0,0,0,15q�5      $��Center=�5      �� 5!   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5"      �� $��Фамилия:��6   $	��100��5#      $��Center=�5$      �� 5%      -   5         ��Name$ 
txtSurname��5%      $	��200��5&      ��5'      �� *	Surname+ �� UpdateSourceTrigger$ PropertyChanged=�5(      �� 5*   
   $��2��6   $ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5+      �� $��Имя:��6   $	��100��5,      $��Center=�5-      �� 5.      -   5        $ txtName��5.      $	��200��5/      ��50      �� *Name+$ PropertyChanged=�51      �� 53   
   $��3��6   $ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�54      �� $��Отчество:��6   $	��100��55      $��Center=�56      �� 57      -   5        $ txtPatronymic��57      $	��200��58      ��59      �� *
Patronymic+$ PropertyChanged=�5:      �� 5<   
   $��4��6   $ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5=      �� $ ��Дата рождения:��6   $	��100��5>      $��Center=�5?      �� 5@      -   5        $ txtBirthday��5@      $	��120��5A       � ToolTip$E ?Формат: ГГГГ-ММ-ДД (например: 2025-03-28)��5B      5C      �� 5E   
   $��5��6   $ 
Horizontal=�6"   $��0,0,0,15q�6;   .+�5F      �� $��Опыт (лет):��6   $	��100��5G      $��Center=�5H      �� 5I      -   5        $ txtExperience��5I      $	��200��5J      ��5K      �� *ExperienceYears+$ PropertyChanged=�5L      � 5N   
   $��6��6   �� 5P   
   $��7��6   $ 
Horizontal=�5Q      $��Right=�5R      .+�5S      �� -   5        $��Сохранить��5S      $	��100��5T      $��0,0,10,0q�5U      5V      �� 5W      -   5        $��Отмена��5W      $	��100��5X      5Y      5Z      5[      5\      