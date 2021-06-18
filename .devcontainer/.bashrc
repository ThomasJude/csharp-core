#
# ~/.bashrc
#

# If not running interactively, don't do anything
[[ $- != *i* ]] && return

PS1='[\u@\h \W]\$ '

# aliases
alias grep='grep --color=auto'
alias ls='ls --color=auto'

# functions
function appendPath {
  if [ ! -z $1 ]; then
    export PATH=${PATH}:$1
  fi
}

# path
appendPath /app/scripts
appendPath ${HOME}/.dotnet/tools

# variables
export DOTNET_ROOT="/opt/dotnet"
export APP_ROOT="/app"
