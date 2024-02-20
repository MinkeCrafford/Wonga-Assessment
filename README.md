# Wonga-Assessment

#         Setup           #
---------------------------

# Erlang
Download & Install
Go to Controll Panel 
    Advanced system setting 
        add Enviroment Variables
            at users, click new, add variable name(%ERLANG_HOME%) and at value click browse and choose folder where its installed
Go to CMD
    ECHO %ERLANG_HOME%

# RabbitMQ
Download & Install
Go to CMD
    C:\Program Files\RabbitMQ Server\rabbitmq_server-3.12.13>cd sbin
    Check if running correctly (3 plug ins)
Go to http://localhost:15672/
    Type in guest for username and password

# Git
Create new repository
Open VS
GO to remote Explorer 
Open Repostory 

# VS code
Once repository is open
Open terminal 
    Type dotnet new console --name Send
        creates Send Folder
        open folder with cd Send
        run dotnet add package RabbitMQ.Client (add the client dependency)
    Type dotnet new console --name Receive
        creates Receive Folder
        open folder with cd Receive
        run dotnet add package RabbitMQ.Client (add the client dependency)


#         Code          #
-------------------------
 
# Send 
Add Library
Create Connection to RabbitMQ service
Declare message queue
    Print "Enter your name:" to console
        Prompt user for input
    Print out "Hello my name is, " with user input after
        Encode the message (string to bytes) in UTF8 format
Send message to Receiver
Promt user to exit program when done 


# Receive
Add Library
Create Connection to RabbitMQ service
Declare message queue
Create consumer to receive the message and cosume message in queue
    Decode message (bytes to string)
Print message "Hello (user input), I am your father!"
Consume message 
Promt user to exit program when done 


#         Sources Used         #
--------------------------------

# Links to Websites/Youtube Videos

https://rabbitmq.com/tutorials/tutorial-one-dotnet.html
https://youtube.com/playlist?list=PLalrWAGybpB-UHbRDhFsBgXJM1g6T4IvO&si=5FHEyvISSf2UC2Y3
https://medium.com/@nikitinsn6/a-beginners-guide-to-rabbitmq-and-how-to-use-it-in-net-446662e53ea2

# Downloads

https://rabbitmq.com/install-windows.html#installer
https://www.erlang.org/downloads
