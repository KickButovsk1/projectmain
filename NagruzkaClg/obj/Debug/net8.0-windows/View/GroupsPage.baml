   M S B A M L   `   `   `  ����  NagruzkaClg!    NagruzkaClg.View.GroupsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� 
Background
  �   � N� Title$ 
GroupsPage��5      $
��1000��6   $
��1920��6(   .��5	      � $��10q�6   
���   � � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   
���   � �� Padding$ 10q�61   ._�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5      �� $��
Поиск��6   
�������$��Center=�6<   $��0 0 15 0q�6W   $��25(�6i   $
��Bold"�6w   �� 5      $��18(�6   $
��Bold"�6(   
���   �
�������$��50��6`   $	��200��6l   $
��Left=�6x   $��Center=�6�   $��0,0,20,0q�6�   �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      �� -   5         ��Name$ AddGroupButton��5      $��20(�6T   
�������
���   �
�������$��Добавить��6�   $��50��6�   $	��200��6�   $��8q�6�   �� 5      -   5        $ DeleteGroupButton��5      $��20(�6Z   
�������
���   �
�������$��Удалить��6�   $��50��6�   $	��200��6�   $��8q�6�   �� 5      -   5        $ 
EditButton��5      $��20(�6L   
�������
���   �
�������$ ��Редактировать��6�   $��50��6�   $	��200��6�   $��8q�6�   5      5      5      �� 5   
   $��1��6   $��15q�6   
���   ����	#FFDDDDDD$��1q�5   )   ._�5      �� -   5         ��Name$ GroupsListView��5       �� SelectionMode$ Single=�6N   
�������
���   ���6/   �� *Groups+ �� View 5      �� 5       .P�5!      �� $��Имя��6)   	 �� Width$		 300��6\   
 �� DisplayMemberBinding
 66   �� *Name+6\   �� 5"      $ ��Специальность��6)   $		 300��6q   
 6@   �� *Specialize.Name+6q   �� 5#      $0��*Платная или бесплатная��6)   $		 300��6�   
 6I   �� *FreeOrSpend.FreeSpend+6�   �� 5$      $!��Форма обучения��6)   $		 300��6u   
 6A   �� *ObuchenieForm.Form+6u   �� 5%      $��Номер курса��6)   $		 300��6r   
 6>   �� *Course.CourseLevel+6r   5&      5(      5)      5*      5+      