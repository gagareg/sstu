clc
clear all
t = 0:0.01:0.1;
k=exp(-66.045*t);
s = exp(-68.65*t);
g= -0.001336*k
l=-0.004346*s
figure(1)
plotyy(t,k,t,s)
grid
figure(2)
plotyy(t,g,t,l)
grid
