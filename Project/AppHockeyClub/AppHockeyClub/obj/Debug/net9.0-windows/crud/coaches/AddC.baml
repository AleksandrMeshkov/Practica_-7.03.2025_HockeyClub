   M S B A M L   `   `   `  ����H  DAppHockeyClub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:AppHockeyClub.crud.coachesAppHockeyClub.crud.coaches  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   %    AppHockeyClub.crud.coaches.AddC   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:AppHockeyClub.crud.coaches     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$%  Добавить тренера��5	   	   $	��400��6"   $	��400��6/    � WindowStartupLocation$ CenterScreen=�5
   	    � 
ResizeMode$ NoResize=�5   	   .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $)��#Добавление тренера��6   $��0��5      $��16(�5      $
��Bold"�5      $��0,0,0,15q�5      $��Center=�5      �� 5    
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5!      �� $��Фамилия:��6   $	��100��5"      $��Center=�5#      �� 5$      -   5         ��Name$ 
txtSurname��5$      $	��200��5%      5&      �� 5(   
   $��2��6   $ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5)      �� $��Имя:��6   $	��100��5*      $��Center=�5+      �� 5,      -   5        $ txtName��5,      $	��200��5-      5.      �� 50   
   $��3��6   $ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�51      �� $��Отчество:��6   $	��100��52      $��Center=�53      �� 54      -   5        $ txtPatronymic��54      $	��200��55      56      �� 58   
   $��4��6   $ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�59      �� $ ��Дата рождения:��6   $	��100��5:      $��Center=�5;      �� 5<      -   5        $ txtBirthDate��5<      $	��120��5=      $��Center=�5>       � ToolTip$E ?Формат: ГГГГ-ММ-ДД (например: 2025-03-28)��5?      ��5@      �� *DateBirthdayString+ �� UpdateSourceTrigger$ PropertyChanged=�5A      �� 5C   
   $��5��6   $ 
Horizontal=�6"   $��0,0,0,15q�6;   .+�5D      �� $��Опыт (лет):��6   $	��100��5E      $��Center=�5F      �� 5G      -   5        $ txtExperience��5G      $	��200��5H      5I      � 5K   
   $��6��6   �� 5M   
   $��7��6   $ 
Horizontal=�6"   $��Right=�6;   .+�5N      �� -   5        $��Сохранить��5N      $	��100��5O      $��0,0,10,0q�5P      5Q      �� 5R      -   5        $��Отмена��5R      $	��100��5S      5T      5U      5V      5W      