#-------------------------------------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See https://go.microsoft.com/fwlink/?linkid=2090316 for license information.
#-------------------------------------------------------------------------------------------------------------

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS development
ENV USER=dev
RUN apt-get update
# setup dev user
RUN apt-get -y install sudo 
RUN useradd -m -s /bin/bash $USER
RUN echo "$USER ALL=(ALL:ALL) NOPASSWD: ALL" >> /etc/sudoers.d/$USER
USER $USER
WORKDIR /home/$USER
COPY .bashrc .
RUN ln -sf /app/.devcontainer/.bashrc /home/$USER/.bashrc
# setup envrionment
USER root
RUN apt-get -y install --no-install-recommends git openssh-client iproute2 procps gnupg curl apt-transport-https lsb-release
RUN wget -O ~/vsls-reqs https://aka.ms/vsls-linux-prereq-script && chmod +x ~/vsls-reqs && ~/vsls-reqs
RUN dotnet tool install --global dotnet-ef \
    && echo 'export PATH="$PATH:/root/.dotnet/tools"' >> ~/.bashrc \
    && echo 'export DOTNET_ROOT="/opt/dotnet"' >> ~/.bashrc \
    && su -c 'dotnet tool install --global dotnet-ef' $USER
WORKDIR /app
USER $USER