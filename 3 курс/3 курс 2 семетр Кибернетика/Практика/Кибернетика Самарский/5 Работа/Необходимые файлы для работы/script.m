clc
clear all
w=tf([7],[49 7.7 1])
u=tf([10],[196 15.4 1])
v=tf([10],[784 30.8 1])
figure(1)
bode(w)
figure(2)
bode(u)
figure(3)
bode(v)
figure(4)
bode(w,u,v)
grid
