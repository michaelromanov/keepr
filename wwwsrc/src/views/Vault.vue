<template>
    <div>
        <h1>{{vault.name}}</h1>
        <div class="card" style="width: 18rem;" v-for="vaultkeep in vaultKeeps" :key="vaultkeep.id">
            <img :src="vaultkeep.img"  class="card-img-top" alt="..." />
         <div class="card-body">
            <h5 class="card-title">{{vaultkeep.name}}</h5>
            <p class="card-text">{{vaultkeep.description}}</p>
            <button class="btn btn-danger" @click="deleteKeepFromVault(vaultkeep.id)">Delete Keep From Vault</button>
        </div>
        </div> 
    </div>
</template>

<script>

export default {
    name: 'Vault', 
    mounted() {
        // if(!this.vault.id){
        //     this.$store.dispatch("getVault", this.vaultId)
        // }
        return this.store.dispatch("getVaultKeeps", this.vault.id)
    }, 
    computed: {
        vault(){return this.$store.state.vault
        }, 
        user() {return this.$store.state.user
        },
        vaultId() {
            return this.$route.params.id
         }, 
        vaultKeeps() {return this.$store.state.vaultKeeps}
        },
    data() {
        return {}
    }, 
    methods: {
        deleteKeepFromVault(id){
            let data = {vaultId:this.vault.id, keepId:id, userId:""}
            this.$store.dispatch("delVaultKeep", data)
        }
    }

}
</script>

<style>

</style>
