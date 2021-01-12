FROM mcr.microsoft.com/mssql/server:2019-CU8-ubuntu-16.04
RUN mkdir -p /usr/work
WORKDIR /usr/work

COPY . /usr/work

USER root
RUN chmod +x /usr/work/run-initialization.sh
#USER mssql

ENV SA_PASSWORD=Test@123
ENV ACCEPT_EULA=Y
ENV MSSQL_PID=Express

EXPOSE 1433

CMD /bin/bash ./entrypoint.sh
