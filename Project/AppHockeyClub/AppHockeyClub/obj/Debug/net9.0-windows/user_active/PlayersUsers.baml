   M S B A M L   `   `   `  ����H  DAppHockeyClub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AppHockeyClub.user_activeAppHockeyClub.user_active  5   	   ,    &AppHockeyClub.user_active.PlayersUsers   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:AppHockeyClub.user_active     5   	     � Title$  Игроки��5   
   $	��450��6   $	��800��6&    � WindowStartupLocation$ CenterScreen=�5	   
    � 	Resources 5         ActionButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding	 �� Triggers
 P� Property P� Value  ColumnHeaderStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader  DataGridStyle&   System.Windows.Controls.DataGrid��%�  &	        &	 e    &	 |    7  �� 5   
   " ��6*   .�5      ��  � ��
 ���� 6+   �� 5       � �� �	#FF3E3E406,   �� 5       � ��$ 1q�60   �� 5       � ��
 �����6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 10q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 4��5      # z��5      ._�5      �� #��z��6/   #��z��5   )   5       5!      5#      	 5$      P� 5%      
 �@J�IsMouseOver$
 True��61   . �5&      ��  � �� �	#FF3E3E4063   �� 5'       � �� �	#FF007ACC64   5(      P� 5)      
 � ��$
 True��6/   . �5*      ��  � �� �	#FF007ACC63   �� 5+       � �� �	#FF007ACC64   5,      5.      �� 51   
   "  6*   .�52      ��  � �� �	#FF2D2D306+   �� 53       � ��
 �����6+   �� 54       � ��$
 Bold"�6+   �� 55       � ��$ 0,0,0,1q�60   �� 56       � �� �	#FF3E3E406,   �� 57       � ��$
 10,5q�6(   58      �� 5;   
   "  6&   .�5<      ��  � �� �	#FF2525266+   �� 5=       � ��
 �����6+   �� 5>       � �� �	#FF3E3E406,   �� 5?       � ��$ 1q�60   �� 5@       �@ RowBackground �	#FF2525266.   �� 5A        �@ AlternatingRowBackground �	#FF2D2D3069   �� 5B       �@ GridLinesVisibility$
 None=�64   �� 5C       �@ HeadersVisibility$ Column=�62   �� 5D       � ��$
 True��6>   �� 5E       �@��PanningMode$
 Both=�69   �� 5F       �@��IsFlicksEnabled$ False��67   �� 5G       �@ ColumnHeaderStyle8   62   �� 5H       �@ SelectionMode$ Single=�6.   �� 5I       �@ SelectionUnit$ FullRow=�6.   �� 5J       �@ CanUserAddRows$ False��6/   5K      5L      .��5N      � ���	#FF252526 � RowDefinitions 5O   
   �� 5P      $
��Auto �6   �� 5Q      $��* �6   �� 5R      $
��Auto �6   .+�5V   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   $
��Left=�6G   $��Center=�6b   .+�5W      �� -   5        $��← Назад��5W      #��[  5X      $��0,0,20,0q�5Z      �� 5[      $!��Список игроков��6   
�������$��18(�5]      $
��Bold"�5^      5_        5b   
   -   5          Name$ PlayersDataGrid��5b      $��1��5c      $��
10,0,10,10q�5d      #��[ 5e         AutoGenerateColumns$ False��5f         Columns 5g      0  *System.Windows.Controls.DataGridTextColumn  5h      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5j   !   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5i   !   �� *	PlayersId+5j   !     5k      $ Фамилия��6%   $ * 5m   !    5l   !   �� *	Surname+5m   !     5n      $ Имя��6%   $ * 5p   !    5o   !   �� *Name+5p   !     5q      $ Отчество��6%   $ * 5s   !    5r   !   �� *
Patronymic+5s   !     5t      $ Дата рождения��6%   $
 Auto 5v   !    5u   !   �� *DateBirthday+ �� StringFormat$ {0:dd.MM.yyyy}��5v   !     5w      $ Рост (см)��6%   $
 Auto 5y   !    5x   !   �� *Height+5y   !     5z      $ Вес (кг)��6%   $
 Auto 5|   !    5{   !   �� *Weight+5|   !   5~      5�      5�      