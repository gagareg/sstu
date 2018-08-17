clc
clear all
t = 0:0.005:0.1;
k=exp(-66.008*t);
g= -0.003475*k
figure(1)
plot(t,k)
grid
figure(2)
plot(t,g)
grid
