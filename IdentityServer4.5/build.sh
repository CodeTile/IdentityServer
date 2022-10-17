#!/usr/bin/env bash
set -euo pipefail

rm -rf nuget
mkdir nuget

dotnet tool restore

#
#
# ##########################################
pushd ./IdentityServer4.5.Storage
./build.sh "$@"
popd
#
#
# ##########################################
pushd ./IdentityServer4.5
./build.sh "$@"
popd
#
# ##########################################
# copy generated nuget packages
cd IdentityServer4.5.Storage/bin/Release
cp *.nupkg ../../../nuget
cd ../../../
# ##########################################
# copy generated nuget packages
cd IdentityServer4.5/bin/Release
cp *.nupkg ../../../nuget
